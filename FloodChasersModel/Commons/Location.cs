using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Commons
{
    public class Location
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
    }
}
