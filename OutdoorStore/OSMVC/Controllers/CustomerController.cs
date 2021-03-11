using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSBL;
using OSModels;
using OSMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSMVC.Controllers
{
    public class CustomerController : Controller
    {
        private IStoreBL _storeBL;
        private IMapper _mapper;

        public CustomerController(IStoreBL sbl, IMapper mapper)
        {
            _storeBL = sbl;
            _mapper = mapper;
        }

        // GET: CustomerController
        public ActionResult Login(string inputEmail/*, string pass*/)
        {
            if(_storeBL.CustomerExists(inputEmail/*, pass*/))
            {
                ViewBag.Customer = _storeBL.GetCustomerByEmail(inputEmail);
                ViewBag.orderCount = _storeBL.GetOrdersByCustomer(inputEmail).Count;

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
