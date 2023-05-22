using System.ComponentModel.DataAnnotations;

namespace ModelsApi.Models.DTOs
{
	public class UpdateManagerDTO
	{

		[Required]
		[MaxLength(64)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(32)]
		public string LastName { get; set; }

		[Required]
		[MaxLength(254)]
		public string Email { get; set; }

		[Required]
		[MaxLength(20)]
		public string PhoneNumber { get; set; }

		[Required]
		public string Birthdate { get; set; }

		[Required]
		[MaxLength(100)]
		public string University { get; set; }
	}
}
