using ItemCatalogue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemCatalogue.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Add DbSet's for each model needed to be included in the database.
        public DbSet<BaseItem> BaseItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<InvItem> InvItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvItem>()
                .Property(b => b.Quality)
                .HasDefaultValue(ItemQuality.Basic);

            modelBuilder.Entity<CompositeItem>()
                .HasKey(s => new { s.ParentItemID, s.ChildItemID });
            modelBuilder.Entity<CompositeItem>()
                .Property(c => c.Amount)
                .HasDefaultValue(1);


            modelBuilder.Seed();
        }
    }
}
