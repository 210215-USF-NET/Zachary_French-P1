using System.Collections.Generic;
using OSModels;

namespace OSBL
{
    public interface IStoreBL
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer c);
        Customer GetCustomerByName(string name);
        Customer GetCustomerByEmail(string email);
        Customer DeleteCustomer(Customer custToBeDeleted);
        Order AddOrder(Order order);
        List<Order> GetOrders();
        List<Order> GetOrdersByCustomer(string email);
        List<Order> GetOrdersByLocation(string name);
        List<Location> GetLocations();
        List<Product> GetProducts();
        List<Product> GetProductsByCategories(ProductCategory pcat);
        Product GetProductByShortName(string str);
        Product GetProductByID(int num);
        bool CustomerExists(string email/*, string pass*/);
        List<Item> GetItems();
        Item AddItem(Item newItem);
        List<Inventory> GetInventories();
        Inventory UpdateInventory(Inventory inv);
        Cart AddCart(Cart newCart);
        List<Cart> GetCarts();
        List<Cart> EmptyCart(List<Cart> carts);
        Inventory AddToCart(Inventory selectedInventory, Customer cust, string quantity);
        Inventory RemoveInventory(Inventory selectedInventory, int quantity);
        Inventory AddInventory(Inventory newInv);
    }
}