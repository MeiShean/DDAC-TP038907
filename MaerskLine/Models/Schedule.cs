using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Vessel Name")]
        public Vessel Vessels { get; set; }
        [Required]
        [Display(Name = "Vessel ID")]
        public int VesselId { get; set; }
        [Required]
        [Display(Name = "Origin Of Shipment")]
        public string LoadPort { get; set; }
        [Required]
        [Display(Name = "Destination Of Shipment")]
        public string DischargePort { get; set; }
        [Required]
        [Display(Name = "Departure Date")]
        public DateTime? DepartureDate { get; set; }
        [Required]
        [Display(Name = "Arrived Date")]
        public DateTime? ArrivedDate { get; set; }
        [Required]
        [Display(Name = "TransitTime")]
        public int TransitTime { get; set; }
        [Required]
        [Display(Name = "Available Space")]
        public int AvailableSpace { get; set; }
    }
}