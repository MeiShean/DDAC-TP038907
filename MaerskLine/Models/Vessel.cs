using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class Vessel
    {
        [Required]
        [Display(Name = "Vessel Id")]
        public int VesselId { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Vessel Name")]
        public string VesselName { get; set; }
    }
}