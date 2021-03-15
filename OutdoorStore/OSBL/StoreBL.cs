using System;
using System.Collections.Generic;
using OSModels;
using OSDL;

namespace OSBL
{
    public class StoreBL : IStoreBL
    {
        private IStoreRepo _repo;
        public StoreBL(IStoreRepo repo)
        {
            _repo = repo;
        }

        public Customer AddCustomer(Customer c)
        {
            return _repo.AddCustomer(c);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public Customer GetCustomerByName(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return _repo.GetCustomerByName(name);
        }

        public Order AddOrder(Order order)
        {
            return _repo.AddOrder(order);
        }

        public List<Order> GetOrders()
        {
            return _repo.GetOrders();
        }

        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }
        public Product GetProductByID(int num)
        {
            return _repo.GetProductByID(num);
        }

        public List<Item> GetItems()
        {
            return _repo.GetItems();
        }

        public List<Product> GetProductsByCategories(ProductCategory pcat)
        {
            return _repo.GetProductsByCategories(pcat);
        }

        public List<Inventory> GetInventories()
        {
            return _repo.GetInventories();
        }

        public Cart AddCart(Cart newCart)
        {
            return _repo.AddCart(newCart);
        }

        public List<Cart> GetCarts()
        {
            return _repo.GetCarts();
        }

        public Item AddItem(Item newItem)
        {
            return _repo.AddItem(newItem);
        }

        public List<Cart> EmptyCart(List<Cart> carts)
        {
            return _repo.EmptyCart(carts);
        }

        public Product GetProductByShortName(string str)
        {
            return _repo.GetProductByShortName(str);
        }

        public Inventory UpdateInventory(Inventory inv)
        {
            return _repo.UpdateInventory(inv);
        }

        public Customer DeleteCustomer(Customer custToBeDeleted)
        {
            return _repo.DeleteCustomer(custToBeDeleted);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _repo.GetCustomerByEmail(email);
        }

        public bool CustomerExists(string email/*, string pass*/)
        {
            return _repo.CustomerExists(email/*, pass*/);
        }

        public List<Order> GetOrdersByCustomer(string email)
        {
            return _repo.GetOrdersByCustomer(email);
        }

        public List<Order> GetOrdersByLocation(string name)
        {
            return _repo.GetOrdersByLocation(name);
        }

        public Inventory AddToCart(Inventory selectedInventory, Customer cust, string quantity)
        {
            return _repo.AddToCart(selectedInventory, cust, quantity);
        }

        public Inventory RemoveInventory(Inventory selectedInventory, int quantity)
        {
            return _repo.RemoveInventory(selectedInventory, quantity);
        }
    }
}