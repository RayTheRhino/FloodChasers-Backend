using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.APIs
{
    public class GetLocation
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
}
