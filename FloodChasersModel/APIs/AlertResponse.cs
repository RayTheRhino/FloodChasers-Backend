using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.APIs
{
    public class AlertResponse
    {
        public string Headline { get; set; }
        public string MessageType { get; set; }
        public string Severity { get; set; }
        public string Urgency { get; set; }
        public string Areas { get; set; }
        public string Category { get; set; }
        public string Certainty { get; set; }
        public string Event { get; set; }
        public string Note { get; set; }
        public string Effective { get; set; }
        public string Expires { get; set; }
        public string Desc { get; set; }
        public string Instruction { get; set; }
    }
}
