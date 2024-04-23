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
        private readonly IWeatherApi _weatherApi;

        public AlertService(IWeatherApi weatherApi)
        {
            _weatherApi = weatherApi;
        }

        public async Task<List<AlertBoundary>> GetAllAlerts(Location location)
        {
            try
            {
                string query = !string.IsNullOrEmpty(location.City) ? location.City : location.Latitude + "," + location.Longitude;
                var alerts = await _weatherApi.GetAlerts(query);
                
                return alerts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
