using FloodChasersModel.Boundaries.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.APIs
{
    public interface IAlertApi
    {
        public Task<List<AlertBoundary>> GetAllAlerts();
        public Task<AlertBoundary> GetAlertsByLatLang(double lat, double lon);
    }
}
