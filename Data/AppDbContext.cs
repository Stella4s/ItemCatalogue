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

            modelBuilder.Entity<ItemComposite>()
                .HasKey(c => new { c.ResultItemID, c.SubItemID });
            modelBuilder.Entity<ItemComposite>()
                .Property(c => c.Amount)
                .HasDefaultValue(1);
            modelBuilder.Entity<ItemComposite>()
                .HasOne(c => c.ResultItem)
                .WithMany(b => b.SubItems)
                .HasForeignKey(c => c.ResultItemID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ItemComposite>()
               .HasOne(c => c.SubItem)
               .WithMany(b => b.ResultItems)
               .HasForeignKey(c => c.SubItemID)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Seed();
        }
    }
}
