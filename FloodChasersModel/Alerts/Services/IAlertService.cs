using FloodChasersModel.Boundaries.Alerts;
using FloodChasersModel.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Alerts.Services
{
    public interface IAlertService
    {
        public Task<List<AlertBoundary>> GetAllAlerts();
        public Task<List<AlertBoundary>> GetAlertsByArea(string area);
    }
}
