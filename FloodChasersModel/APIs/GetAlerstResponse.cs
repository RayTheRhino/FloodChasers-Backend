using FloodChasersModel.Boundaries.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.APIs
{
    public class GetAlerstResponse
    {
        public List<AlertBoundary> Alerts { get; set; }
    }
}
