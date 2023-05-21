using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ModelsApi.Models.Entities;
using ModelsApi.Models;
using static BCrypt.Net.BCrypt;

namespace ModelsApi.Data
{
    public static class DbUtilities
    {
        internal static void SeedData(ApplicationDbContext context, int bcryptWorkfactor)
        {
            context.Database.EnsureCreated();
            if (!context.Chats.Any())
                SeedChat(context);
            if (!context.Accounts.Any())
                SeedAccounts(context, bcryptWorkfactor);
            if (!context.Managers.Any())
                SeedManagers(context);
            if (!context.Annonces.Any())
                SeedAnnonces(context);
            if (!context.Messages.Any()) 
                SeedMessage(context);     
        }

        static void SeedAccounts(ApplicationDbContext context, int bcryptWorkfactor)
        {
            context.Accounts.AddRange(
                // Seed manager
                new EfAccount
                {
                    Email = "user@mail.dk",
                    PwHash = HashPassword("Pas123", bcryptWorkfactor),
                    
                },
                new EfAccount
                {
                    Email = "user2@mail.dk",
                    PwHash = HashPassword("Pas123", bcryptWorkfactor),
                },
                new EfAccount
                {
                    Email = "user3@mail.dk",
                    PwHash = HashPassword("Pas123", bcryptWorkfactor),
                }
            );
            context.SaveChanges();
        }

        static void SeedChat(ApplicationDbContext context)
        {
	        context.Chats.AddRange(
		        new Chat
		        {
                    
		        },
		        new Chat
		        {
			       
		        },
		        new Chat
		        {
			       
		        }
	        );
	        context.SaveChanges();
        }

		static void SeedManagers(ApplicationDbContext context)
        {
            context.Managers.AddRange(
                new EfManager
                {
                    EfAccountId = 1,
                    FirstName = "User",
                    LastName = "sui",
                    Email = "user@mail.dk",
                    Password = "Pas123",
                    PhoneNumber = "12121212",
                    Birthdate = "12-12-2012",
                    University = "AU",

                },
                new EfManager
                {
                    EfAccountId = 2,
                    FirstName = "User",
                    LastName = "suisui",
                    Email = "user2@mail.dk",
                    Password = "Pas123",
                    PhoneNumber = "12121212",
                    Birthdate = "12-12-2012",
                    University = "AU",
                },
                new EfManager
                {
                    EfAccountId = 3,
                    FirstName = "sui",
                    LastName = "suisen",
                    Email = "user3@mail.dk",
                    Password = "Pas123",
                    PhoneNumber = "12121212",
                    Birthdate = "12-12-2012",
                    University = "AU",
                }
                );
                context.SaveChanges();
        }
        static void SeedAnnonces(ApplicationDbContext context)
        {
            context.Annonces.AddRange(
                new Annonce
                {
	                Price = 10.2,
                   Titel = "My first",
                   Kategori = "Bog",
                   Beskrivelse = "Det er en flot bog",
                   Studieretning = "SW",
                   BilledeSti = "images/book.gif",
                   EfManagerId = 1,
                   Stand = "Brugt",
                   ChatId = 1,
                   CheckBoxValue=true,
                   NumberOfWeeks=2
                },
                new Annonce
                {
	                Price = 10.2,
                    Titel = "My first book",
                    Kategori = "Bog",
                    Beskrivelse = "Det asd er en flot bog",
                    Studieretning = "SW",
                    BilledeSti = "images/book.gif",
                    EfManagerId = 2,
                    Stand = "Brugt",
                    ChatId = 2
                },
                new Annonce
                {
	                Price = 1011.2,
                    Titel = "My first book",
                    Kategori = "Bog",
                    Beskrivelse = "Det asd er en flot bog",
                    Studieretning = "SW",
                    BilledeSti = "https://easydrawingguides.com/wp-content/uploads/2020/10/how-to-draw-an-open-book-featured-image-1200.png",
                    EfManagerId = 2,
                    Stand = "Brugt",
                    ChatId = 3
                }
            );
            context.SaveChanges();
        }
        

        
        
        static void SeedMessage(ApplicationDbContext context)
        {
            context.Messages.AddRange(
                new Message
                {
                    Messages = "Hej",
                    ChatId = 1
                },
                new Message
                {
                    Messages = "Hej",
                    ChatId = 2
                },
                new Message
                {
                    Messages = "Hej",
                    ChatId = 1
                }
            );
            context.SaveChanges();
        }
        
    }
}
