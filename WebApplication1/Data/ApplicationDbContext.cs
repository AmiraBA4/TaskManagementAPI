﻿using Microsoft.EntityFrameworkCore;
using TaskManagement.Models;

namespace TaskManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Données de test
            modelBuilder.Entity<User>().HasData(

                new User { Id = "Aurelien", Name = "Aurelien", Email = "Aurelien.test@example.com" },
                new User { Id = "Julien", Name = "Julien", Email = "Julien.test@example.com" },
                new User { Id = "Emilie", Name = "Emilie", Email = "Emilie.test@example.com" },
                new User { Id = "amira", Name = "Amira", Email = "Amira.test@example.com" }



            );

            modelBuilder.Entity<TaskModel>().HasData(
                new TaskModel { Id = 1, Title = "Test Task1", Description = "Test In-Memory Task1", DueDate = DateTime.Now.AddDays(5), IsCompleted = false, UserId = "amira" },
                new TaskModel { Id = 2, Title = "Test Task2", Description = "Test In-Memory Task2", DueDate = DateTime.Now.AddDays(5), IsCompleted = false, UserId = "amira" },
                new TaskModel { Id = 3, Title = "Test Task3", Description = "Test In-Memory Task3", DueDate = DateTime.Now.AddDays(5), IsCompleted = false, UserId = "amira" },
                new TaskModel { Id = 4, Title = "Test Task4", Description = "Test In-Memory Task4", DueDate = DateTime.Now.AddDays(5), IsCompleted = false, UserId = "amira" }

            );
        }
    }
}

