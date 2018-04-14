using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MaerskLine.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MaerskLine.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private ApplicationDbContext _context;


        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<ActionResult> ViewAgent()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var role = await roleManager.FindByNameAsync("Agent");

            var roleUsers = userManager.Users.Where(u => u.Roles.Any(r => r.RoleId == role.Id));

            var viewModel = new ViewAgent
            {
                ViewAgents = roleUsers.ToList()
            };

            return View(viewModel);
        }

        public ActionResult Vessels()
        {

            var vessel = _context.Vessels;
            var viewV = new ViewVessel
            {
                ViewVessels = vessel.ToList()
            };
            return View(viewV);
        }

        public ActionResult ViewSchedules()
        {

            var schedule = _context.Schedules;
            var view = new ViewSchedule
            {
                ListSchedule = schedule.ToList()
            };
            return View(view);
        }

        public ActionResult Schedule()
        {
            var v = _context.Vessels.ToList();
            var viewmodel = new ViewVessel
            {
                ViewVessels = v
            };

            return View(viewmodel);
        }



        [HttpPost]
        public ActionResult Save(Schedule schedule)
        {
            var v = _context.Vessels.ToList();
            var viewmodel = new ViewVessel
            {
                ViewVessels = v
            };


            if (!ModelState.IsValid)
            {

                if (schedule.ArrivedDate < schedule.DepartureDate)
                {
                    ViewBag.Fail = "Please select the arrived data greater than the departure date";
                    return View("Schedule", viewmodel);
                }
            }


            schedule.AvailableSpace = 40;
            schedule.TransitTime = Convert.ToInt32(((TimeSpan)(schedule.ArrivedDate - schedule.DepartureDate)).TotalDays);

            schedule.Vessels = _context.Vessels.SingleOrDefault(s => s.VesselId == schedule.VesselId);


            _context.Schedules.Add(schedule);
            _context.SaveChanges();

            ViewBag.SuccessMessage = "Created successfully";
            return View("Schedule", viewmodel);
        }

        public ActionResult ViewBookings()
        {
            var booking = _context.MakeBooking;
            var book = new ViewBooking
            {
                ListBooking = booking.ToList()
            };
            return View(book);
        }
        }
    }

