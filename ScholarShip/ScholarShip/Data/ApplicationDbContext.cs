using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScholarShip.Models;

namespace ScholarShip.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Annonce> Annonces { get; set; }
		public DbSet<Chat> Chats { get; set; }
		public DbSet<Message> Messages { get; set; }
		
		
	}
}