using FloodChasersModel.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Boundaries.Alerts
{
    public class AlertBoundary
    {
        public string Id {  get; set; }
        public string Headline {  get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public Metadata Metadata { get; set; }
    }
}
