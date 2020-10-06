using ItemCatalogue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Seed Categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 1, Name = "Ingredients" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 2, Name = "Potions" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 3, Name = "Food" });

            //Seed Items
            modelBuilder.Entity<BaseItem>().HasData(new BaseItem
            {
                BaseItemID = 1,
                Name = "Apple",
                BasePrice = 4.50M,
                Description = "A delicious fresh apple.",
                CategoryID = 3
            });
            modelBuilder.Entity<BaseItem>().HasData(new BaseItem
            {
                BaseItemID = 2,
                Name = "ApplePie",
                BasePrice = 23.00M,
                Description = "A classic.",
                CategoryID = 3
            });
            modelBuilder.Entity<BaseItem>().HasData(new BaseItem
            {
                BaseItemID = 3,
                Name = "Flour",
                BasePrice = 2.30M,
                Description = "Regular old flour.",
                CategoryID = 1
            });
            modelBuilder.Entity<BaseItem>().HasData(new BaseItem
            {
                BaseItemID = 4,
                Name = "Apple Extract",
                BasePrice = 6.50M,
                Description = "A fancy way of saying apple juice.",
                CategoryID = 1
            });
            modelBuilder.Entity<BaseItem>().HasData(new BaseItem
            {
                BaseItemID = 5,
                Name = "Health Potion",
                BasePrice = 6.50M,
                Description = "Good in a pinch.",
                CategoryID = 2
            });

        }
    }
}
