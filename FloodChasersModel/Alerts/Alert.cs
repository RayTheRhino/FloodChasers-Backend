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
        public string? Id { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
        public string Serverity { get; set; }
        public string Areas { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
