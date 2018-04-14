using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class ViewBookingVessel
    {
        public Schedule Schedule { get; set; }
        public IEnumerable<Customer> ListCustomer { get; set; }
        public MakeBook Booking { get; set; }

    }
}