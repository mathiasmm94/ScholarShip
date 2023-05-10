﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelsApi.Data;

#nullable disable

namespace ModelsApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230510112852_AddedRegisterUser")]
    partial class AddedRegisterUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ModelsApi.Models.Annonce", b =>
                {
                    b.Property<int>("AnnonceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnnonceId"), 1L, 1);

                    b.Property<string>("Beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BilledeSti")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<long>("EfManagerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Stand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Studieretning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnnonceId");

                    b.HasIndex("ChatId");

                    b.HasIndex("EfManagerId");

                    b.ToTable("Annonces");
                });

            modelBuilder.Entity("ModelsApi.Models.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatId"), 1L, 1);

                    b.Property<long?>("EfManagerId")
                        .HasColumnType("bigint");

                    b.HasKey("ChatId");

                    b.HasIndex("EfManagerId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("ModelsApi.Models.Entities.EfAccount", b =>
                {
                    b.Property<long>("EfAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EfAccountId"), 1L, 1);

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("PwHash")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("EfAccountId");

                    b.HasIndex("ChatId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ModelsApi.Models.Entities.EfManager", b =>
                {
                    b.Property<long>("EfManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EfManagerId"), 1L, 1);

                    b.Property<string>("Birthdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EfAccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EfManagerId");

                    b.HasIndex("EfAccountId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("ModelsApi.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("Messages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ModelsApi.Models.Annonce", b =>
                {
                    b.HasOne("ModelsApi.Models.Chat", "Chat")
                        .WithMany("Annonces")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelsApi.Models.Entities.EfManager", "Manager")
                        .WithMany("Annoncer")
                        .HasForeignKey("EfManagerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("ModelsApi.Models.Chat", b =>
                {
                    b.HasOne("ModelsApi.Models.Entities.EfManager", null)
                        .WithMany("Chats")
                        .HasForeignKey("EfManagerId");
                });

            modelBuilder.Entity("ModelsApi.Models.Entities.EfAccount", b =>
                {
                    b.HasOne("ModelsApi.Models.Chat", null)
                        .WithMany("Profils")
                        .HasForeignKey("ChatId");
                });

            modelBuilder.Entity("ModelsApi.Models.Entities.EfManager", b =>
                {
                    b.HasOne("ModelsApi.Models.Entities.EfAccount", "Account")
                        .WithMany()
                        .HasForeignKey("EfAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("ModelsApi.Models.Message", b =>
                {
                    b.HasOne("ModelsApi.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("ModelsApi.Models.Chat", b =>
                {
                    b.Navigation("Annonces");

                    b.Navigation("Messages");

                    b.Navigation("Profils");
                });

            modelBuilder.Entity("ModelsApi.Models.Entities.EfManager", b =>
                {
                    b.Navigation("Annoncer");

                    b.Navigation("Chats");
                });
#pragma warning restore 612, 618
        }
    }
}