using FloodChasersModel.Alerts;
using FloodChasersModel.Alerts.Services;
using FloodChasersModel.Boundaries.Alerts;
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
        private readonly IGenericDeo<Alert> _alertDao;

        public AlertService(IGenericDeo<Alert> alertDao)
        {
            _alertDao = alertDao;
        }

        public AlertBoundary CreateAlert(AlertBoundary alertBoundary)
        {
            try
            {
                var alert = new Alert
                {
                    Headline = alertBoundary.Headline,
                    Metadata = alertBoundary.Metadata,
                    Description = alertBoundary.Description,
                    Location = alertBoundary.Location
                };
                _alertDao.Add(alert);
                alertBoundary.Id = alert.Id;
                return alertBoundary;

            }catch (Exception )
            {
                throw;
            }
        }

        public AlertBoundary DeleteAlertById(string alertId)
        {
            try
            {
                var alertDelete = _alertDao.GetById(alertId);
                if(alertDelete == null) {
                    throw new Exception("alert was not found");
                }
                //_alertDao.Delete(alertDelete);
                //return
            }
            catch (Exception )
            {
                throw;
            }
        }

        public AlertBoundary DeleteAllAlerts()
        {
            throw new NotImplementedException();
        }

        public AlertBoundary GetAlertById(string alertId)
        {
            try
            {
                var alert = _alertDao.GetById(alertId);
                if( alert == null )
                {
                    throw new Exception("Alert was not found");
                }
                return new AlertBoundary
                {
                    Id = alert.Id,
                    Description = alert.Description,
                    Headline = alert.Headline,
                    Metadata = alert.Metadata,
                    Location = alert.Location
                };
                
            }
            catch (Exception ) 
            {
                throw;

            }
        }

        public List<AlertBoundary> GetAllAlerts(AlertBoundary alertBoundary)
        {
            try
            {
                var alerts = _alertDao.GetAll();
                var alertBoundaries = new List<AlertBoundary>();
                foreach (var alert in alerts)
                {
                    alertBoundaries.Add(new AlertBoundary
                    {
                        Id = alert.Id,
                        Description = alert.Description,
                        Headline = alert.Headline,
                        Metadata = alert.Metadata,
                        Location = alert.Location
                    });
                }
                return alertBoundaries;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AlertBoundary UpdateAlert(AlertBoundary alertBoundary)
        {
            try
            {
                var existingAlert = _alertDao.GetById(alertBoundary.Id);
                if(existingAlert  == null )
                {
                    throw new Exception("Alert was not found");
                }
                existingAlert.Headline = alertBoundary.Headline;
                existingAlert.Metadata = alertBoundary.Metadata;
                existingAlert.Location = alertBoundary.Location;
                existingAlert.Description = alertBoundary.Description;
                _alertDao.Update(existingAlert);
                
                return alertBoundary;
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}
