﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelsApi.Models;
using ModelsApi.Models.Services;

namespace ModelsApi.Models.Entities
{
	public class EfManager
	{
		[Key]
		public long EfManagerId { get; set; }

		[Required]
		[ForeignKey("Account")]
		public long EfAccountId { get; set; }


		public EfAccount? Account { get; set; }

		[Required]
		[MaxLength(64)]
		public string? FirstName { get; set; }

		[Required]
		[MaxLength(32)]
		public string? LastName { get; set; }

		[Required]
		[MaxLength(254)]
		public string? Email { get; set; }

		[Required]
		public string? Password { get; set; }

		[Required]
		[MaxLength(20)]
		public string? PhoneNumber { get; set; }

		[Required]
		public string? Birthdate { get; set; }

		[Required]
		[MaxLength(100)]
		public string? University { get; set; }

		
		
		public List<ChatRoom> ChatRooms { get; set; }
		public List<Annonce> Annoncer { get; set; }
	}
}