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
    }
}
