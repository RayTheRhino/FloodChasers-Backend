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
        public string? Id {  get; set; }
        public string Headline {  get; set; }
        public string Description { get; set; }
        public DateTimeOffset TimeCreated { get; set; }
        public DateTimeOffset TimeUpdated { get; set; }
        public string Severity { get; set; }
        public string Areas { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

    }
}
