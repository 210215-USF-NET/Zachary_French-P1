using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using OSBL;
using OSModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSMVC.Models;
using System.Text.Json;

namespace OSMVC.Controllers
{
    public class ManagerController : Controller
    {
        private IStoreBL _storeBL;
        private IMapper _mapper;
        private Customer _customer;
        private Location _location;

        public ManagerController(IStoreBL sbl, IMapper mapper)
        {
            _storeBL = sbl;
            _mapper = mapper;
        }
        public ActionResult ManagerHome()
        {
            return View();
        }

        public ActionResult CustomerList()
        {

            return View(_storeBL.GetCustomers());
        }

        public ActionResult StoreSelectorOrders()
        {
            return View();
        }

        public ActionResult OrderListByLocation(string store)
        {
            _location = _storeBL.GetLocations().FirstOrDefault(l => l.ID == int.Parse(store));
            _location.Inventory = _storeBL.GetInventories().Where(i => i.LocationID == _location.ID).ToList();
            HttpContext.Session.SetString("storeSelection", JsonSerializer.Serialize(_location));

            List<Order> orders = _storeBL.GetOrdersByLocation(_location.Name);
            List<Item> items = _storeBL.GetItems();
            foreach (Item i in items)
            {
                i.Product = _storeBL.GetProductByID(i.ProdID);
            }
            HttpContext.Session.SetString("orderItems", JsonSerializer.Serialize(items));

            return View(orders);
        }

        public ActionResult StoreSelectorInventory()
        {
            return View();
        }

        public ActionResult InventoryByLocation(string store)
        {
            _location = _storeBL.GetLocations().FirstOrDefault(l => l.ID == int.Parse(store));
            _location.Inventory = _storeBL.GetInventories().Where(i => i.LocationID == _location.ID).ToList();
            HttpContext.Session.SetString("storeSelection", JsonSerializer.Serialize(_location));

            List<Inventory> inv = _storeBL.GetInventories().Where(i => i.LocationID == _location.ID).ToList();
            foreach (Inventory i in inv)
            {
                i.Product = _storeBL.GetProductByID(i.ProductID);
            }

            return View(inv);
        }

        public ActionResult ProductList()
        {

            return View(_storeBL.GetProducts());
        }

        // GET: ManagerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerController/Edit/5
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

        // GET: ManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerController/Delete/5
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
