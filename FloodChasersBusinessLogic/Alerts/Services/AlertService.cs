using FloodChasersLogic.APIs;
using FloodChasersModel.Alerts;
using FloodChasersModel.Alerts.Services;
using FloodChasersModel.APIs;
using FloodChasersModel.Boundaries.Alerts;
using FloodChasersModel.Commons;
using FloodChasersModel.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersLogic.Alerts.Services
{
    public class AlertService : IAlertService
    {
        private IGenericDeo<Alert> _alertService;

        public AlertService(IGenericDeo<Alert> alertService)
        {
            _alertService = alertService;
        }

        public AlertService(AlertsApi alertsApi)
        {
            AlertsApi = alertsApi;
        }

        public AlertsApi AlertsApi { get; }

        public Task<AlertBoundary> GetAlertsByLatLang(double lat, double lon)
        {
            throw new NotImplementedException();
        }

        public Task<List<AlertBoundary>> GetAllAlerts()
        {
            throw new NotImplementedException();
        }
    }
}
