using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.APIs
{
    
    public class GetWeatherResponse
    {
        public GetLocation Location { get; set; }
        public GetAlertResponse Alerts { get; set; }
    }
}
