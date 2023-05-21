﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelsApi.Data;
using ModelsApi.Models.DTOs;
using ModelsApi.Models.Entities;
using ModelsApi.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static BCrypt.Net.BCrypt;

namespace ModelsApi.Controllers
{
    /// <summary>
    /// Use this API to login and change password.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;

        public AccountController(ApplicationDbContext context,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// You must login before you can use any other api call.
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Token</returns>
        /// <response code="200">Returns the token</response>
        /// <response code="400">If login is null or validation fails</response>
        /// 
        [HttpPost("login"), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Token>> Login([FromBody]Login login)
        {
            if (login != null)
            {
                login.Email = login.Email.ToLowerInvariant();
                var account = await _context.Accounts.Where(u => u.Email == login.Email)
                    .FirstOrDefaultAsync().ConfigureAwait(false);
                var efManager = await _context.Managers.FirstOrDefaultAsync(m => m.EfManagerId == account.EfAccountId);

                if (account != null)
                {
                    var validPwd = Verify(login.Password, account.PwHash);
                    if (validPwd)
                    {
	                    long modelId = -1;
                        /*if (!account.IsManager)
                        {
                            var model = await _context.Models.Where(m => m.EfAccountId == account.EfAccountId)
                                .FirstOrDefaultAsync().ConfigureAwait(false);
                            if (model != null)
                                modelId = model.EfModelId;
                        }*/
                        var jwt = GenerateToken(account.Email, modelId, efManager.FirstName);
                        var token = new Token() { JWT = jwt };
                        return token;
                    }
                }
            }

            ModelState.AddModelError("Message", "Invalid login");
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Use to change the password.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        /// <response code="200">If success</response>
        /// <response code="400">If incorrect data</response>
        /// 
        [HttpPut("Password")]
        public async Task<ActionResult<Token>> ChangePassword([FromBody] changePassword login)
        {
            if (login == null)
            {
                ModelState.AddModelError("Message", "Data missing");
                return BadRequest(ModelState);
            }
            login.Email = login.Email.ToLowerInvariant();
            var account = await _context.Accounts.Where(u => u.Email == login.Email)
                .FirstOrDefaultAsync().ConfigureAwait(false);

            if (account == null)
            {
                ModelState.AddModelError("email", "Not found!");
                return BadRequest(ModelState);
            }
            var validPwd = Verify(login.OldPassword, account.PwHash);
            if (validPwd)
            {

                account.PwHash = HashPassword(login.Password, _appSettings.BcryptWorkfactor);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Ok();
            }
            else
            {
                ModelState.AddModelError("oldPassword", "No match");
                return BadRequest(ModelState);
            }
        }


        /// <summary>
        /// Use to register new user.
        /// </summary>
		[HttpPost("register")]
		[AllowAnonymous]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Register([FromBody] RegisterUser userDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(new {error="Not valid"});
			}

            userDto.Email = userDto.Email.ToLowerInvariant();
            if (await _context.Managers.AnyAsync(u => u.Email == userDto.Email))
			{
                return BadRequest(new { error = "Email already exists" });
            }

			if (await _context.Managers.AnyAsync(u => u.PhoneNumber == userDto.PhoneNumber))
			{
                return BadRequest(new { error = "Phonenumber already exists" });
            }

            var pwHash = HashPassword(userDto.Password, _appSettings.BcryptWorkfactor);

			var user = new EfManager()
			{
				FirstName = userDto.FirstName,
				LastName = userDto.LastName,
				Birthdate = userDto.Birthdate,
				Email = userDto.Email,
				Password = pwHash,
				University = userDto.University,
                PhoneNumber = userDto.PhoneNumber,
                Account = new EfAccount{Email = userDto.Email, PwHash = pwHash}
			};

			_context.Managers.Add(user);
			await _context.SaveChangesAsync().ConfigureAwait(false);

			return Created("", null);
		}



		private string GenerateToken(string email, long modelId,string name)
        {
            Claim roleClaim;
            

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim("Name", name),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var token = new JwtSecurityToken(
                 new JwtHeader(new SigningCredentials(
                      new SymmetricSecurityKey(key),
                      SecurityAlgorithms.HmacSha256Signature)),
                      new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}