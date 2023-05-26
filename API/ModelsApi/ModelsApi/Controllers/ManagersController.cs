using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ModelsApi.Data;
using ModelsApi.Models.DTOs;
using ModelsApi.Models.Entities;
using ModelsApi.Utilities;
using static BCrypt.Net.BCrypt;

namespace ModelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Manager")]
    public class ManagersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;

        public ManagersController(ApplicationDbContext context,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EfManager>>> GetManagers()
        {
            return await _context.Managers.ToListAsync();
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EfManager>> GetManager(long id)
        {
            var manager = await _context.Managers.FindAsync(id);

            if (manager == null)
            {
                return NotFound();
            }

            return manager;
        }

        // PUT: api/Managers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(long id, UpdateManagerDTO managerDTO)
        {
	        var manager = await _context.Managers.FindAsync(id);

	        if (manager == null)
	        {
		        return NotFound();
	        }
	        
			manager.FirstName = managerDTO.FirstName;
            manager.LastName = managerDTO.LastName;
            manager.Email = managerDTO.Email;
            manager.PhoneNumber = managerDTO.PhoneNumber;
            manager.Birthdate = managerDTO.Birthdate;
            manager.University = managerDTO.University;
           

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var updatedManager = await _context.Managers.FindAsync(id);

            return Ok(updatedManager);
            
        }


        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EfManager>> DeleteManager(long id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(manager.EfAccountId);
            _context.Accounts.Remove(account);
            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();

            return manager;
        }

        private bool ManagerExists(long id)
        {
            return _context.Managers.Any(e => e.EfManagerId == id);
        }
    }
}
