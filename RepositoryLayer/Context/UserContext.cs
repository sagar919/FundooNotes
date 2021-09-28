﻿
using CommonLayer.Model.NotesModels;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;




namespace RepositoryLayer.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Notes> Notes { get; set; }

        public DbSet<Category> Category { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FirstName = "Uncle",
                LastName = "Bob",
                Email = "uncle.bob@gmail.com",
                Password = "1234",
                CreatedAt = new DateTime(2020, 02, 02),
                ModifiedAt = new DateTime(2020, 02, 02)

            }, new User
            {
                UserId = 2,
                FirstName = "Aunty",
                LastName = "Bob",
                Email = "aunty.bob@gmail.com",
                Password = "1234",
                CreatedAt = new DateTime(2020, 02, 02),
                ModifiedAt = new DateTime(2020, 02, 02)
            }
            );

            modelBuilder.Entity<Notes>()

                .HasData(new Notes
                {
                    Id = 1,
                    Category = "public",
                    Title = "FirstNote",
                    Message = "This is my first note",
                    Image = "image1",
                    Color = "Blue",
                    IsPin = false,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    AddReminder = DateTime.MinValue,
                    UserId = 1,
                    IsArchive = false,
                    IsNote = false,
                    IsTrash = false,
                   

                });

            modelBuilder.Entity<Category>().HasData(
               new Category {Id = 1, Name = "Public" },
               new Category { Id = 2, Name = "Private" },
               new Category { Id = 3, Name = "Default" });






        }

    }
    
}
