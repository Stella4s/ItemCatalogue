﻿// <auto-generated />
using ItemCatalogue.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ItemCatalogue.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201006125221_Inventory")]
    partial class Inventory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ItemCatalogue.Models.BaseItem", b =>
                {
                    b.Property<int>("BaseItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BaseItemID");

                    b.HasIndex("CategoryID");

                    b.ToTable("BaseItems");

                    b.HasData(
                        new
                        {
                            BaseItemID = 1,
                            BasePrice = 4.50m,
                            CategoryID = 3,
                            Description = "A delicious fresh apple.",
                            Name = "Apple"
                        },
                        new
                        {
                            BaseItemID = 2,
                            BasePrice = 23.00m,
                            CategoryID = 3,
                            Description = "A classic.",
                            Name = "ApplePie"
                        },
                        new
                        {
                            BaseItemID = 3,
                            BasePrice = 2.30m,
                            CategoryID = 1,
                            Description = "Regular old flour.",
                            Name = "Flour"
                        },
                        new
                        {
                            BaseItemID = 4,
                            BasePrice = 6.50m,
                            CategoryID = 1,
                            Description = "A fancy way of saying apple juice.",
                            Name = "Apple Extract"
                        },
                        new
                        {
                            BaseItemID = 5,
                            BasePrice = 6.50m,
                            CategoryID = 2,
                            Description = "Good in a pinch.",
                            Name = "Health Potion"
                        },
                        new
                        {
                            BaseItemID = 6,
                            BasePrice = 9.00m,
                            CategoryID = 1,
                            Description = "Yikes.",
                            Name = "Newt's eye"
                        });
                });

            modelBuilder.Entity("ItemCatalogue.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "Ingredients"
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "Potions"
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = "Food"
                        });
                });

            modelBuilder.Entity("ItemCatalogue.Models.InvItem", b =>
                {
                    b.Property<int>("InvItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseItemID")
                        .HasColumnType("int");

                    b.Property<string>("InventoryID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.HasKey("InvItemID");

                    b.HasIndex("BaseItemID");

                    b.ToTable("InvItems");
                });

            modelBuilder.Entity("ItemCatalogue.Models.BaseItem", b =>
                {
                    b.HasOne("ItemCatalogue.Models.Category", "MainCategory")
                        .WithMany("Items")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItemCatalogue.Models.InvItem", b =>
                {
                    b.HasOne("ItemCatalogue.Models.BaseItem", "BaseItem")
                        .WithMany()
                        .HasForeignKey("BaseItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
