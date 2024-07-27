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
        private IAlertApi _alertApi;

        public AlertService(IAlertApi alertApi)
        {
            _alertApi = alertApi;
        }

        public async Task<List<AlertBoundary>> GetAlertsByArea(string area)
        {
            return await _alertApi.GetAlertsByArea(area);
        }

        public async Task<List<AlertBoundary>> GetAllAlerts()
        {
            return await _alertApi.GetAllAlerts();
        }
    }
}
