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
            if (!context.ChatRooms.Any())
                SeedChatRooms(context);
            if (!context.Messages.Any())
                SeedMessage(context);
            if (!context.Annonces.Any())
                SeedAnnonces(context);
           

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
                
                 
                },
                new ChatRoom
                {
                 
			       
                },
                new ChatRoom
                {
                },
                 new ChatRoom
                 {


                 },
                new ChatRoom
                {


                },
                new ChatRoom
                {
                },
                 new ChatRoom
                 {


                 },
                new ChatRoom
                {


                },
                new ChatRoom
                {
                },
                 new ChatRoom
                 {


                 },
                new ChatRoom
                {


                },
                new ChatRoom
                {
                },
                 new ChatRoom
                 {


                 },
                new ChatRoom
                {


                },
                new ChatRoom
                {
                },
                new ChatRoom
                {


                },
                new ChatRoom
                {


                },
                new ChatRoom
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
	                Price = 69420.0,
                   Titel = "The Book of Eve",
                   Kategori = "Bog",
                   Beskrivelse = "Det er en flot bog",
                   Studieretning = "SW",
                   BilledeSti = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSehNExO7Os6_qM7ZpPmqGhgLK84E6pnPvaPQ&usqp=CAU",
                   EfManagerId = 1,
                   Stand = "Som ny",
                   ChatRoomId = 1,
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
                    BilledeSti = "https://images.unsplash.com/photo-1544947950-fa07a98d237f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=387&q=80",
                    EfManagerId = 2,
                    Stand = "Velbrugt",
                    ChatRoomId = 2,
                    CheckBoxValue = false,
                    NumberOfWeeks = 1
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
                    Stand = "Slidt",
                    ChatRoomId = 3,
                    CheckBoxValue = true,
                    NumberOfWeeks = 4
                },
                 new Annonce
                 {
                     Price = 1337.0,
                     Titel = "SoftwareBog",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 2. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIFeglxsRSVHYEoqnrd9sHuqImBKcJc0_nrg&usqp=CAU",
                     EfManagerId = 3,
                     Stand = "Slidt",
                     ChatRoomId = 4,
                     CheckBoxValue = true,
                     NumberOfWeeks = 3
                 },
                 new Annonce
                 {
                     Price = 1011.2,
                     Titel = "DatabaseBog",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://rituals.scene7.com/is/image/rituals/The_book_of_Rituals_TheArtOfSoulfulLiving_PRO1-1?resMode=sharp2&fmt=png-alpha&wid=1000",
                     EfManagerId = 3,
                     Stand = "Slidt",
                     ChatRoomId = 5,
                     CheckBoxValue = true,
                     NumberOfWeeks = 3
                 },
                 new Annonce
                 {
                     Price = 420.0,
                     Titel = "BackendBog",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Som ny",
                     ChatRoomId = 6,
                     CheckBoxValue = true,
                     NumberOfWeeks = 3
                 },
                 new Annonce
                 {
                     Price = 1011.2,
                     Titel = "FrontendBog",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Velbrugt",
                     ChatRoomId = 7,
                     CheckBoxValue = true,
                     NumberOfWeeks = 2
                 },
                 new Annonce
                 {
                     Price = 120.0,
                     Titel = "SoftwareTest Bog",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Som ny",
                     ChatRoomId = 8,
                     CheckBoxValue = true,
                     NumberOfWeeks = 3
                 },
                 new Annonce
                 {
                     Price = 200.0,
                     Titel = "Backend Bog fra backend faget",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Slidt",
                     ChatRoomId = 9,
                     CheckBoxValue = true,
                     NumberOfWeeks = 3
                 },
                 new Annonce
                 {
                     Price = 150.0,
                     Titel = "Database Modelling and design",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Slidt",
                     ChatRoomId = 10,
                     CheckBoxValue = true,
                     NumberOfWeeks = 3
                 },
                 new Annonce
                 {
                     Price = 175.0,
                     Titel = "Database Modelling and design",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Velbrugt",
                     ChatRoomId = 11,
                     CheckBoxValue = true,
                     NumberOfWeeks = 3
                 },
                 new Annonce
                 {
                     Price = 400.0,
                     Titel = "Database Modelling and design",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Velbrugt",
                     ChatRoomId = 12,
                     CheckBoxValue = false,
                     NumberOfWeeks = 1
                 },
                 new Annonce
                 {
                     Price = 50.0,
                     Titel = "Projektmappe",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 2. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Som ny",
                     ChatRoomId = 13,
                     CheckBoxValue = true,
                     NumberOfWeeks = 1
                 },
                 new Annonce
                 {
                     Price = 150.0,
                     Titel = "Kroppens atonomi",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "ST",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Velbrugt",
                     ChatRoomId = 14,
                     CheckBoxValue = false,
                     NumberOfWeeks = 3
                 },
                 new Annonce
                 {
                     Price = 150.0,
                     Titel = "Minecraft: How to defeat ender dragon",
                     Kategori = "Bog",
                     Beskrivelse = "Bog til dig som ikke kan klare minecraft",
                     Studieretning = "EE",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Slidt",
                     ChatRoomId = 15,
                     CheckBoxValue = true,
                     NumberOfWeeks = 3
                 },
                 new Annonce
                 {
                     Price = 500.0,
                     Titel = "Database Modelling and design",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Slidt",
                     ChatRoomId = 16,
                     CheckBoxValue = true,
                     NumberOfWeeks = 3
                 },
                 new Annonce
                 {
                     Price = 195.0,
                     Titel = "Database Modelling and design",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Slidt",
                     ChatRoomId = 17,
                     CheckBoxValue = false,
                     NumberOfWeeks = 1
                 },
                 new Annonce
                 {
                     Price = 225.0,
                     Titel = "Database Modelling and design",
                     Kategori = "Bog",
                     Beskrivelse = "Bog fra 4. semester SW",
                     Studieretning = "SW",
                     BilledeSti = "https://images.twinkl.co.uk/tr/image/upload/t_illustration/illustation/book.png",
                     EfManagerId = 3,
                     Stand = "Slidt",
                     ChatRoomId = 18,
                     CheckBoxValue = true,
                     NumberOfWeeks = 4
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
                    Content = "Hej",
                    EfManagerId = 1,
                    TimeStamp = DateTime.Now
                },
                new Message
                {
                    ChatRoomId = 2,
                    Content = "Hej",
                    EfManagerId = 2,
                    TimeStamp = DateTime.Now
                },
                new Message
                {
                    ChatRoomId = 3,
                    Content = "Hej",
                    EfManagerId = 3,
                    TimeStamp = DateTime.Now
                }
            );
            context.SaveChanges();
        }
        

    }
}
