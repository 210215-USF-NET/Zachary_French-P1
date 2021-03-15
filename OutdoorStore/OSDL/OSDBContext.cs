using Microsoft.EntityFrameworkCore;
using OSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSDL
{
    public class OSDBContext : DbContext
    {
        public OSDBContext (DbContextOptions options) : base(options)
        {

        }
        protected OSDBContext ()
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tell the database to automatically generate and increment the IDs
            //as these objects are created
            modelBuilder.Entity<Customer>()
                .Property(cust => cust.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>()
                .Property(p => p.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Location>()
                .Property(l => l.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .Property(o => o.ID)
                .ValueGeneratedOnAdd();
            //modelBuilder.Entity<Order>().HasOne(o => o.Location);
            //modelBuilder.Entity<Order>().HasOne(o => o.Customer);

            modelBuilder.Entity<Cart>()
                .Property(c => c.ID)
                .ValueGeneratedOnAdd();
            //modelBuilder.Entity<Cart.HasOne(c => c.Customer);
            //modelBuilder.Entity<Cart>().HasOne(c => c.Location);
            //modelBuilder.Entity<Cart.HasOne(c => c.Product);

            modelBuilder.Entity<Item>()
                .Property(i => i.ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Inventory>()
                .Property(i => i.ID)
                .ValueGeneratedOnAdd();
        }

    }
}
