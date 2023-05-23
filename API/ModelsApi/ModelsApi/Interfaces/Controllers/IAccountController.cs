using ModelsApi.Models.DTOs;

namespace ModelsApi.Interfaces.Controllers
{
	public interface IAccountController
	{
		Task<Token> Login(Login login);
		Task<Token> Register(RegisterUser userDto);
	}
}
