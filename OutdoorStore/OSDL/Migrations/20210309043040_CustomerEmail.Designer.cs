﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OSDL;

namespace OSDL.Migrations
{
    [DbContext(typeof(OSDBContext))]
    [Migration("20210309043040_CustomerEmail")]
    partial class CustomerEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("OSModels.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustID")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("integer");

                    b.Property<int>("LocID")
                        .HasColumnType("integer");

                    b.Property<int?>("LocationID")
                        .HasColumnType("integer");

                    b.Property<int>("ProdID")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("LocationID");

                    b.HasIndex("ProductID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OSModels.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OSModels.Inventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("LocationID")
                        .HasColumnType("integer");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("OSModels.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.Property<int>("ProdID")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("OSModels.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("OSModels.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustID")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LocID")
                        .HasColumnType("integer");

                    b.Property<int?>("LocationID")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("LocationID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OSModels.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OSModels.Cart", b =>
                {
                    b.HasOne("OSModels.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.HasOne("OSModels.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID");

                    b.HasOne("OSModels.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.Navigation("Customer");

                    b.Navigation("Location");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OSModels.Inventory", b =>
                {
                    b.HasOne("OSModels.Location", null)
                        .WithMany("Inventory")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OSModels.Item", b =>
                {
                    b.HasOne("OSModels.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OSModels.Order", b =>
                {
                    b.HasOne("OSModels.Customer", "Customer")
                        .WithMany("orderHistory")
                        .HasForeignKey("CustomerID");

                    b.HasOne("OSModels.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID");

                    b.Navigation("Customer");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("OSModels.Customer", b =>
                {
                    b.Navigation("orderHistory");
                });

            modelBuilder.Entity("OSModels.Location", b =>
                {
                    b.Navigation("Inventory");
                });
#pragma warning restore 612, 618
        }
    }
}
