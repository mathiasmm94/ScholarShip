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

		public DbSet<Annonce> Annonces => Set<Annonce>();
		public DbSet<Chat> Chats => Set<Chat>();
		public DbSet<Message> Messages => Set<Message>();
		
	}
}