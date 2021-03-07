using System.Collections.Generic;
using OSModels;

namespace OSBL
{
    public interface IStoreBL
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer c);
        Customer GetCustomerByName(string name);
        void AddOrder(Order order);
        List<Order> GetOrders();
        List<Location> GetLocations();
        List<Product> GetProducts();
        List<Product> GetProductsByCategories(ProductCategory pcat);
        Product GetProductByShortName(string str);
        Product GetProductByID(int num);
        List<Item> GetItems();
        Item AddItem(Item newItem);
        List<Inventory> GetInventories();
        void UpdateInventory(Inventory inv);
        Cart AddCart(Cart newCart);
        List<Cart> GetCarts();
        void EmptyCart();
    }
}