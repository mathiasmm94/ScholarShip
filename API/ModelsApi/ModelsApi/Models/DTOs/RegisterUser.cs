using System.ComponentModel.DataAnnotations;

namespace ModelsApi.Models.DTOs
{
	public class RegisterUser
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[Phone]
		public string PhoneNxmber { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		[Required]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required]
		[StringLength(50)]
		public string University { get; set; }

		[Required]
		[RegularExpression(@"^([0-9]{2})-([0-9]{2})-([0-9]{4})$",
			ErrorMessage = "The Birthdate must be in the format 'dd-mm-yyyy'")]
		public string Birthdate { get; set; }
	}

}
