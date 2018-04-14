using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaerskLine.Models
{
    public class ViewAgent
    {
        public int Id { get; set; }
        public List<ApplicationUser> ViewAgents { get; set; }
    }
}