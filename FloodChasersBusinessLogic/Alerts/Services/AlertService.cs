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

        public async Task<List<AlertBoundary>> GetAllAlerts(Location location)
        {
            try
            {
                
                var alerts = await _weatherApi.GetAlerts(query);
                
                return alerts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Task<List<AlertBoundary>> GetAllAlerts(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
