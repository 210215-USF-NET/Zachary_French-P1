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

        public Inventory AddToCart(Inventory selectedInventory, Customer cust, string quantity)
        {
            _context.Carts.Add(new Cart
            {
                CustID = cust.ID,
                LocID = selectedInventory.LocationID,
                ProdID = selectedInventory.ProductID,
                Quantity = int.Parse(quantity)
            });

            _context.SaveChanges();

            return selectedInventory;
        }

        public bool CustomerExists(string email/*, string pass*/)
        {
            try
            {
                return !(_context.Customers.AsNoTracking().FirstOrDefault(cust => cust.Email.ToLower().Equals(email.ToLower())) == null);
            }
            catch(Exception)
            {
                return true;
            }
        }

        public Customer DeleteCustomer(Customer custToBeDeleted)
        {
            _context.Customers.Remove(custToBeDeleted);
            _context.SaveChanges();
            return custToBeDeleted;
        }

        public List<Cart> EmptyCart(List<Cart> carts)
        {
            _context.Carts.RemoveRange(carts);
            _context.SaveChanges();

            return carts;
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
            List<Inventory> invs = _context.Inventories
                .AsNoTracking()
                .Select(inv => inv)
                .ToList();

            foreach(Inventory i in invs)
            {
                i.Product = GetProductByID(i.ProductID);
            }

            return invs;
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

        public List<Order> GetOrdersByCustomer(string email)
        {
            Customer c = _context.Customers
                .AsNoTracking()
                .FirstOrDefault(c => c.Email.ToLower().Equals(email.ToLower()));

            return _context.Orders
                .AsNoTracking()
                .Where(o => o.CustID == c.ID)
                .ToList();
        }

        public List<Order> GetOrdersByLocation(string name)
        {
            Location l = _context.Locations
                .AsNoTracking()
                .FirstOrDefault(l => l.Name.ToLower().Equals(name.ToLower()));

            return _context.Orders
                .AsNoTracking()
                .Where(o => o.LocID == l.ID)
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

        public Inventory RemoveInventory(Inventory selectedInventory, int quantity)
        {
            Inventory newInv = selectedInventory;

            newInv.Quantity -= quantity;
            UpdateInventory(newInv);

            return selectedInventory;
        }

        public Inventory UpdateInventory(Inventory inv)
        {
            Inventory oldInv = _context.Inventories
                .FirstOrDefault(i => i.ID == inv.ID);

            _context.Entry(oldInv).CurrentValues.SetValues(inv);

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return inv;
        }
    }
}
