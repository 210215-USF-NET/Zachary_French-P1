using Microsoft.EntityFrameworkCore;
using OSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSDL
{
    public class OSRepoDB : IStoreRepo
    {
        private readonly OSDBContext _context;
        public OSRepoDB(OSDBContext context)
        {
            _context = context;
        }

        public Cart AddCart(Cart newCart)
        {
            throw new NotImplementedException();
        }

        public Customer AddCustomer(Customer newCust)
        {
            _context.Customers.Add(newCust);
            _context.SaveChanges();
            return newCust;
        }

        public Item AddItem(Item newItem)
        {
            _context.Items.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public Order AddOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }

        public bool CustomerExists(string email, string pass)
        {
            throw new NotImplementedException();
        }

        public Customer DeleteCustomer(Customer custToBeDeleted)
        {
            _context.Customers.Remove(custToBeDeleted);
            _context.SaveChanges();
            return custToBeDeleted;
        }

        public List<Cart> EmptyCart()
        {
            List<Cart> fullCart = GetCarts();
            _context.Carts.RemoveRange(fullCart);
            return fullCart;
        }

        public List<Cart> GetCarts()
        {
            return _context.Carts
                .AsNoTracking()
                .Select(cart => cart)
                .ToList();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers
                .AsNoTracking()
                .FirstOrDefault(cust => cust.Email.ToLower().Equals(email.ToLower()));
        }

        public Customer GetCustomerByName(string name)
        {
            return _context.Customers
                .AsNoTracking()
                .FirstOrDefault(cust => cust.Name.ToLower().Equals(name.ToLower()));
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers
                .AsNoTracking()
                .Select(cust => cust)
                .ToList();
        }

        public List<Inventory> GetInventories()
        {
            return _context.Inventories
                .AsNoTracking()
                .Select(inv => inv)
                .ToList();
        }

        public List<Item> GetItems()
        {
            return _context.Items
                .AsNoTracking()
                .Select(itm => itm)
                .ToList();
        }

        public List<Location> GetLocations()
        {
            return _context.Locations
                .AsNoTracking()
                .Select(loc => loc)
                .ToList();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders
                .AsNoTracking()
                .Select(o => o)
                .ToList();
        }

        public Product GetProductByID(int num)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.ID == num);
        }

        public Product GetProductByShortName(string str)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.ShortName.ToLower().Equals(str.ToLower()));
        }

        public List<Product> GetProducts()
        {
            return _context.Products
                .AsNoTracking()
                .Select(p => p)
                .ToList();
        }

        public List<Product> GetProductsByCategories(ProductCategory pcat)
        {
            switch (pcat)
            {
                /*case ProductCategory.Backpacks:
                    return _context.Products.AsNoTracking().Select(x => x.Category == 1).ToList();
                case ProductCategory.Camping:
                    return _context.Products.AsNoTracking().Select(x => x.Category == 2).ToList();
                case ProductCategory.Climbing:
                    return _context.Products.AsNoTracking().Select(x => x.Category == 3).ToList();
                case ProductCategory.Clothing:
                    return _context.Products.AsNoTracking().Select(x => x.Category == 4).ToList();
                case ProductCategory.Shoes:
                    return _context.Products.AsNoTracking().Select(x => x.Category == 5).ToList();*/
                default:
                    throw new NotImplementedException();
            }
        }

        public Inventory UpdateInventory(Inventory inv)
        {
            throw new NotImplementedException();
        }
    }
}
