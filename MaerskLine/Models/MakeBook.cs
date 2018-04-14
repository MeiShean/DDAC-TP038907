using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class MakeBook
    {
        public int Id { get; set; }
        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }
        public ApplicationUser Agent { get; set; }
        public string AgentId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public string Item { get; set; }
        [Required]
        public int Space { get; set; }
    }
}