using FloodChasersModel.Boundaries.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Alerts.Services
{
    public interface IAlertService
    {
        public AlertBoundary GetAlertById(string alertId);
        public AlertBoundary CreateAlert(AlertBoundary alertBoundary);

        public List<AlertBoundary>GetAllAlerts(AlertBoundary alertBoundary);
        public AlertBoundary UpdateAlert(AlertBoundary alertBoundary);
        public AlertBoundary DeleteAlertById(string alertId);
        public AlertBoundary DeleteAllAlerts();

    }
}
