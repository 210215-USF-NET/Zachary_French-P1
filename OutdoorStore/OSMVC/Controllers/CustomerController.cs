using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSBL;
using OSModels;
using OSMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OSMVC.Controllers
{
    public class CustomerController : Controller
    {
        private IStoreBL _storeBL;
        private IMapper _mapper;
        private Customer _customer;
        private Location _location;

        public CustomerController(IStoreBL sbl, IMapper mapper)
        {
            _storeBL = sbl;
            _mapper = mapper;
        }

        // GET: CustomerController
        public ActionResult Login(string inputEmail/*, string pass*/)
        {
            if(inputEmail.Equals("test@t"))
            {
                _customer = _storeBL.GetCustomerByEmail("tate@tate.tate");
                _customer.OrderHistory = _storeBL.GetOrdersByCustomer("tate@tate.tate");
                HttpContext.Session.SetString("customerData", JsonSerializer.Serialize(_customer));

                return View("CustomerHome");
            }
            else if(inputEmail.Equals("e@e"))
            {
                return View("~/Views/Manager/ManagerHome.cshtml");
            }
            else if (_storeBL.CustomerExists(inputEmail/*, pass*/))
            {
                _customer = _storeBL.GetCustomerByEmail(inputEmail);
                _customer.OrderHistory = _storeBL.GetOrdersByCustomer(inputEmail);
                HttpContext.Session.SetString("customerData", JsonSerializer.Serialize(_customer));

                return View("CustomerHome");
            }
            else
            {
                return View("Create");
            }
        }

        public ActionResult CustomerHome()
        {
            return View();
        }

        public ActionResult StoreSelector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductView(string store)
        {
            _location = _storeBL.GetLocations().FirstOrDefault(l => l.ID == int.Parse(store));
            _location.Inventory = _storeBL.GetInventories().Where(i => i.LocationID == _location.ID).ToList();
            HttpContext.Session.SetString("storeSelection", JsonSerializer.Serialize(_location));

            return View();
        }

        public ActionResult AddToCart(string quantity, string cartProduct)
        {
            _customer = JsonSerializer.Deserialize<Customer>(HttpContext.Session.GetString("customerData"));
            _location = JsonSerializer.Deserialize<Location>(HttpContext.Session.GetString("storeSelection"));

            Inventory selectedInventory = _storeBL.GetInventories()
                .FirstOrDefault(p =>
                p.ProductID == int.Parse(cartProduct)
                && p.LocationID == _location.ID);

            _storeBL.AddToCart(selectedInventory, _customer, quantity);

            /*_storeBL.RemoveInventory(selectedInventory, quantity);*/

            return View("ProductView");
        }

        public ActionResult Cart()
        {
            _customer = JsonSerializer.Deserialize<Customer>(HttpContext.Session.GetString("customerData"));
            List<Cart> inv = _storeBL.GetCarts().Where(c => c.CustID == _customer.ID).ToList();

            foreach(Cart c in inv)
            {
                c.Product = _storeBL.GetProductByID(c.ProdID);
            }
            return View(inv);
        }

        /// <summary>
        /// Takes products currently in the cart for the customer currenlty logged-in at the most recently browsed store
        /// and stores all the necessary information in the Orders and Items tables.  Finally once all data has been stored
        /// correctly, the Cart items are removed from the Cart, leaving behind all the items for other customers and stores.
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public ActionResult Checkout(int tp)
        {
            //grab variables
            _customer = JsonSerializer.Deserialize<Customer>(HttpContext.Session.GetString("customerData"));
            _location = JsonSerializer.Deserialize<Location>(HttpContext.Session.GetString("storeSelection"));
            List<Cart> carts = _storeBL.GetCarts().Where(c => c.CustID == _customer.ID).ToList();
            int orderID = _storeBL.GetOrders().LastOrDefault().ID + 1;
            Cart cart = carts.Last();

            //Add Order to table
            Order newOrder = new Order()
            {
                CustID = _customer.ID,
                LocID = _location.ID,
                Date = DateTime.Now,
                TotalPrice = tp
            };
            _storeBL.AddOrder(newOrder);

            //loop
            foreach (Cart c in carts)
            {
                //add Items to table
                Item itm = new Item()
                {
                    OrderID = orderID,
                    ProdID = c.ProdID,
                    Quantity = c.Quantity,
                };
                _storeBL.AddItem(itm);

                //reduce stock in appropriate store
                Inventory oldInv = _storeBL.GetInventories()
                    .FirstOrDefault(i => i.ProductID == c.ProdID && i.LocationID == _location.ID);
                _storeBL.RemoveInventory(oldInv, c.Quantity);
            }

            //Empty Cart
            _storeBL.EmptyCart(_storeBL.GetCarts()
                .Where(c => c.ProdID == cart.ProdID && c.LocID == cart.LocID).ToList());

            return View("CustomerHome");
        }

        public ActionResult OrderHistory()
        {
            _customer = JsonSerializer.Deserialize<Customer>(HttpContext.Session.GetString("customerData"));
            List<Order> orders = _storeBL.GetOrders().Where(o => o.CustID == _customer.ID).ToList();
            List<Item> items = _storeBL.GetItems();
            foreach(Item i in items)
            {
                i.Product = _storeBL.GetProductByID(i.ProdID);
            }
            HttpContext.Session.SetString("orderItems", JsonSerializer.Serialize(items));
            
            return View(orders);

        }


            // GET: CustomerController
            public ActionResult Index()
        {
            return View(_storeBL.GetCustomers().Select(cust => _mapper.parseCustomerToVM(cust)).ToList());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(string name)
        {
            return View(_mapper.parseToCCVM(_storeBL.GetCustomerByName(name)));
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreateVM newCust)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _storeBL.AddCustomer(_mapper.parseToCust(newCust));
                    return RedirectToAction("Login", new { email = newCust.Email });
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(string name)
        {
            _storeBL.DeleteCustomer(_storeBL.GetCustomerByName(name));
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
