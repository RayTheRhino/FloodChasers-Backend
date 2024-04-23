using FloodChasersModel.Boundaries.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.APIs
{
    public interface IWeatherApi
    {
        public Task<List<AlertBoundary>> GetAlerts(string query, int days = 14, string alerts = "yes");
    }
}
