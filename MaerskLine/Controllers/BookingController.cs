using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MaerskLine.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace MaerskLine.Controllers
{
    [Authorize(Roles = "Agent")]
    public class BookingController : Controller
    {
        private ApplicationDbContext _context;

        public string AgentId { get; private set; }

        public BookingController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: MakeBook
        public ActionResult SearchVessel()
        {
            //get
            //{
            //    var v = _context.Schedules.ToList();
            //    var viewmodel = new ViewSchedule
            //    {
            //        ListSchedule = v
            //    };

            //    return View(viewmodel);
            //}
            return View();
        }

        public ActionResult Search(string lport, string dport)
        {
            var v = _context.Schedules.Include(s => s.Vessels).ToList();

            List<Schedule> newlist = new List<Schedule>();

            foreach (var singlev in v)
            {
                if (singlev.LoadPort == lport && singlev.DischargePort == dport)
                {
                    newlist.Add(singlev);
                }
                //else if (singlev.LoadPort != lport && singlev.DischargePort != dport)
                //{
                //    ViewBag.SuccessMessage = "Sorry, the port existing does not match your search";
                //    return View("SearchVessel");
                //}

            }

            var load = _context.Schedules.FirstOrDefault();
            var l = load.LoadPort;
            var d = load.DischargePort;

            if (!l.Equals(lport) && !d.Equals(dport))
            {
                ViewBag.Fail = "Sorry, please enter the available port for shipment";
                return View("SearchVessel");
            }

            var viewmodel = new ViewSchedule
            {
                ListSchedule = newlist
            };

            return View("ResultSearch", viewmodel);

        }

        public ActionResult ResultSearch()
        {
            var v = _context.Schedules.ToList();
            var viewmodel = new ViewSchedule
            {
                ListSchedule = v
            };

            return View();
        }

        public ActionResult BookingForm(int id)
        {

            var s = _context.Schedules.Include(x => x.Vessels).Single(x => x.Id == id);
            var c = _context.Customers.ToList();
            var b = new MakeBook();
            b.ScheduleId = s.Id;

            if (s == null)
                return HttpNotFound();

            var viewmodel = new ViewBookingVessel
            {
                Schedule = s,
                ListCustomer = c,
                Booking = b
            };
            //        var schedule = db schedule with id same with sId
            //var customers = db all customers
            //var booking = new Booking()

            //create viewmodel, customers, schedule, booking

            return View("BookingForm", viewmodel);
        }

        [HttpPost]
        [Authorize(Roles = "Agent")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ViewBookingVessel bookvessel)
        {
            MakeBook book = new MakeBook();
            var schedule = _context.Schedules.Include(s => s.Vessels).SingleOrDefault(s => s.Id == bookvessel.Booking.ScheduleId);
            var customers = _context.Customers.ToList();
            var viewModel = new ViewBookingVessel
            {
                Booking = bookvessel.Booking,
                Schedule = schedule,
                ListCustomer = customers
            };

            if (!ModelState.IsValid)
            {
                return View("BookingForm", viewModel);
            }

            if (bookvessel.Booking.Space > schedule.AvailableSpace)
            {
                ViewBag.ErrorMesssage = "The space for this vessel is full.";
                return View("BookingForm", viewModel);
            }


            //Assign Schedule
            book.Schedule = schedule;
            book.ScheduleId = bookvessel.Booking.ScheduleId;

            var searchspace = _context.Schedules.SingleOrDefault(s => s.Id == book.ScheduleId);
            var usedSpace = bookvessel.Booking.Space;
            searchspace.AvailableSpace -= usedSpace;

            //Assign Agent
            book.AgentId = User.Identity.GetUserId();
            book.Agent = _context.Users.FirstOrDefault(x => x.Id == book.AgentId);

            //Assign Customer
            book.CustomerId = bookvessel.Booking.CustomerId;
            book.Customer = _context.Customers.SingleOrDefault(s => s.Id == book.CustomerId);

            book.Space = bookvessel.Booking.Space;
            book.Item = bookvessel.Booking.Item;


            _context.MakeBooking.Add(book);
            _context.SaveChanges();

            ViewBag.Success = "Book Successful";
            return View("BookingForm", viewModel);
        }

      }
}