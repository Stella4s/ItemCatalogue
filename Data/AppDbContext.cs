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
                .Property(iv => iv.Quality)
                .HasDefaultValue(ItemQuality.Basic);

            modelBuilder.Entity<CompositeItem>()
                .HasKey(c => new { c.ParentItemID, c.ChildItemID });
            modelBuilder.Entity<CompositeItem>()
                .Property(c => c.Amount)
                .HasDefaultValue(1);
            modelBuilder.Entity<CompositeItem>()
                .HasOne(c => c.ParentItem)
                .WithMany(b => b.CompositeItems)
                .HasForeignKey(c => c.ParentItemID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Seed();
        }
    }
}
