using ItemCatalogue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Add DbSet's for each model needed to be included in the database.
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 1, Name = "Ingredients" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 2, Name = "Potions" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 3, Name = "Food" });

            //Seed Items
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemID = 1,
                Name = "Apple",
                BasePrice = 4.50M,
                Description = "A delicious fresh apple.",
                Quality = ItemQuality.Basic,
                CategoryID = 3
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemID = 2,
                Name = "ApplePie",
                BasePrice = 23.00M,
                Description = "A classic.",
                Quality = ItemQuality.Basic,
                CategoryID = 3
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemID = 3,
                Name = "Flour",
                BasePrice = 2.30M,
                Description = "Regular old flour.",
                Quality = ItemQuality.Basic,
                CategoryID = 1
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemID = 4,
                Name = "Apple Extract",
                BasePrice = 6.50M,
                Description = "A fancy way of saying apple juice.",
                Quality = ItemQuality.Basic,
                CategoryID = 1
            });
            modelBuilder.Entity<Item>().HasData(new Item
            {
                ItemID = 5,
                Name = "Health Potion",
                BasePrice = 6.50M,
                Description = "Good in a pinch.",
                Quality = ItemQuality.Basic,
                CategoryID = 2
            });

        }
    }
}
