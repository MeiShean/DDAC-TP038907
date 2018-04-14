using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class ViewVessel
    {
        public List<Vessel> ViewVessels { get; set; }
        public Schedule schedule { get; set; }
    }
}