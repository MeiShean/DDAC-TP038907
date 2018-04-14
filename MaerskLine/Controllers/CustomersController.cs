using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MaerskLine.Models;

namespace MaerskLine.Controllers
{
    [Authorize(Roles = "Agent")]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            ViewBag.SuccessMessage = "Created successfully";
            return View("New");
        }
    }
}