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

        public void AddOrder(Order order)
        {
            _repo.AddOrder(order);
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

        public void EmptyCart()
        {
            _repo.EmptyCart();
        }

        public Product GetProductByShortName(string str)
        {
            return _repo.GetProductByShortName(str);
        }

        public void UpdateInventory(Inventory inv)
        {
            _repo.UpdateInventory(inv);
        }
    }
}