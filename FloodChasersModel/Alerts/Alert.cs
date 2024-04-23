using FloodChasersModel.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Alerts
{
    public class Alert
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Headline { get; set; }
        public string? Description { get; set; }
        public Location Location { get; set; } 
        public DateTime TimeCreated { get; set; } = DateTime.Now;
    }
}
