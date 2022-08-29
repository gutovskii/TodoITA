using Microsoft.EntityFrameworkCore;
using System;
using TodoITA.DataAccess.Entities;
using TodoITA.DataAccess.ExtensionMethods;

namespace TodoITA.DataAccess
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options) { }

        public DbSet<TodoCategory> TodoCategories { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
    }
}
