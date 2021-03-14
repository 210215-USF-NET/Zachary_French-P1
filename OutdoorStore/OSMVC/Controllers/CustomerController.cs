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
            _location = JsonSerializer.Deserialize<Location>(HttpContext.Session.GetString("storeSelection"));
            _customer = JsonSerializer.Deserialize<Customer>(HttpContext.Session.GetString("customerData"));

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
            List<Cart> inv = _storeBL.GetCarts();
            foreach(Cart c in inv)
            {
                c.Product = _storeBL.GetProductByID(c.ProdID);
            }
            return View(inv);
        }

        public ActionResult Checkout()
        {
            return View();
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
