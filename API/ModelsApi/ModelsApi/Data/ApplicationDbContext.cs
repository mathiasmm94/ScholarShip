using Microsoft.EntityFrameworkCore;
using ModelsApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsApi.Models;
using ModelsApi.Models.Services;

namespace ModelsApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }
        
        public DbSet<Annonce> Annonces { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<EfAccount> Accounts { get; set; }
        public DbSet<EfManager> Managers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfManager>()
                .HasIndex(p => p.Email)
                .IsUnique();

            modelBuilder.Entity<Annonce>()
                .HasOne<EfManager>(a => a.Manager)
                .WithMany(m => m.Annoncer)
                .HasForeignKey(a => a.EfManagerId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
