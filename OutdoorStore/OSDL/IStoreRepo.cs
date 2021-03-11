using OSModels;
using System.Collections.Generic;

namespace OSDL
{
    public interface IStoreRepo
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer newCust);
        Customer GetCustomerByName(string name);
        Customer GetCustomerByEmail(string email);
        Customer DeleteCustomer(Customer custToBeDeleted);
        Order AddOrder(Order order);
        List<Order> GetOrders();
        List<Item> GetItems();
        Item AddItem(Item newItem);
        List<Location> GetLocations();
        List<Product> GetProducts();
        List<Product> GetProductsByCategories(ProductCategory pcat);
        Product GetProductByShortName(string str);
        Product GetProductByID(int num);
        List<Inventory> GetInventories();
        Inventory UpdateInventory(Inventory inv);
        Cart AddCart(Cart newCart);
        List<Cart> GetCarts();
        List<Cart> EmptyCart();
        bool CustomerExists(string email/*, string pass*/);
        List<Order> GetOrdersByCustomer(string email);
        List<Order> GetOrdersByLocation(string name);
    }
}