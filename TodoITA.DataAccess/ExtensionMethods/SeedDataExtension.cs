using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TodoITA.DataAccess.Entities;

namespace TodoITA.DataAccess.ExtensionMethods
{
    public static class SeedDataExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoCategory>().HasData(
                new TodoCategory
                {
                    Id = 1,
                    Title = "Home"
                },
                new TodoCategory
                {
                    Id = 2,
                    Title = "Work"
                },
                new TodoCategory
                {
                    Id = 3,
                    Title = "Gym"
                });

            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem
                {
                    Id = 1,
                    Text = "Room Cleaning",
                    Description = "My part but not the neighbour",
                    IsDone = false,
                    TodoCategoryId = 1
                },
                new TodoItem
                {
                    Id = 2,
                    Text = "To Cook",
                    Description = "Boil eggs and cook the meat",
                    IsDone = true,
                    TodoCategoryId = 1
                },
                new TodoItem
                {
                    Id = 3,
                    Text = "Wash the Dishes",
                    Description = "With Mr.Proper",
                    IsDone = false,
                    TodoCategoryId = 1
                },
                new TodoItem
                {
                    Id = 4,
                    Text = "Make Backend",
                    Description = "ASP.NET Core 3.1, MS SQL",
                    IsDone = true,
                    TodoCategoryId = 2
                },
                new TodoItem
                {
                    Id = 5,
                    Text = "Make Frontend",
                    Description = "React, Redux",
                    IsDone = false,
                    TodoCategoryId = 2
                },
                new TodoItem
                {
                    Id = 6,
                    Text = "Make Tests",
                    Description = "NUnit",
                    IsDone = false,
                    TodoCategoryId = 2
                },
                new TodoItem
                {
                    Id = 7,
                    Text = "Legs",
                    Description = "Squats, Lunges, Extension, Caviar",
                    IsDone = true,
                    TodoCategoryId = 3
                },
                new TodoItem
                {
                    Id = 8,
                    Text = "Shoulders",
                    IsDone = true,
                    Description = "Front, Middle, Back",
                    TodoCategoryId = 3
                });
        }
    }
}
