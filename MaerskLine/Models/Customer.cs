using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Contact Number")]
        public string Contact_No { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}