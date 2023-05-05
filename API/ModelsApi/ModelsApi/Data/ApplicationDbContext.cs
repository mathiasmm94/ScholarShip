using Microsoft.EntityFrameworkCore;
using ModelsApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScholarShip.Models;

namespace ModelsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }
        
        public DbSet<Annonce> Annonces { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<EfAccount> Accounts { get; set; }
        public DbSet<EfManager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfManager>()
                .HasIndex(p => p.Email)
                .IsUnique();
        }
    }
}
