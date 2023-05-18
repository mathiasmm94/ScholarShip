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
using ModelsApi.Models.Services;
using static BCrypt.Net.BCrypt;

namespace ModelsApi.Data
{
    public static class DbUtilities
    {
        internal static void SeedData(ApplicationDbContext context, int bcryptWorkfactor)
        {
            context.Database.EnsureCreated();
            
            if (!context.Accounts.Any())
                SeedAccounts(context, bcryptWorkfactor);
            if (!context.Managers.Any())
                SeedManagers(context);
            if (!context.UserChatRooms.Any())
                SeedUserChatRooms(context);
            if (!context.Messages.Any())
                SeedMessage(context);
            if (!context.Annonces.Any())
                SeedAnnonces(context);
            if (!context.ChatRooms.Any())
                SeedChatRooms(context);
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
        
        static void SeedChatRooms(ApplicationDbContext context)
        {
            context.ChatRooms.AddRange(
                new ChatRoom
                {
                    Name = "Annonce",
                 
                },
                new ChatRoom
                {
                    Name = "Annonce",
			       
                },
                new ChatRoom
                {
                    Name = "Annonce",
                }
            );
            context.SaveChanges();
        }
        static void SeedUserChatRooms(ApplicationDbContext context)
        {
            context.UserChatRooms.AddRange(
                new UserChatRoom
                {
                    EfManagerId = 1,
                    ChatRoomId = 1,
                    
                },
                new UserChatRoom
                {
                    EfManagerId = 2,
                   ChatRoomId = 2,
                },
                new UserChatRoom
                {
                    EfManagerId = 3,
                   ChatRoomId = 3,
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
                    Email = "user2@mail.dk",
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
                    ChatId = 1
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
                    BilledeSti = "images/book.gif",
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
                    ChatRoomId = 1,
                    MessageId = 1,
                    Content = "Hej",
                    EfManagerId = 1,
                },
                new Message
                {
                    ChatRoomId = 3,
                    MessageId = 1,
                    Content = "Hej",
                    EfManagerId = 2,
                },
                new Message
                {
                    ChatRoomId = 3,
                    MessageId = 1,
                    Content = "Hej",
                    EfManagerId = 3,
                }
            );
            context.SaveChanges();
        }
        

    }
}
