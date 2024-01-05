using FloodChasersModel.Alerts.Services;
using FloodChasersModel.Boundaries.Alerts;
using Microsoft.AspNetCore.Mvc;

namespace FloodChasersAPI.Controllers
{
    [ApiController]
    [Route("Alerts")]
    public class AlertController : ControllerBase
    {
        private IAlertService _alertService;
        public AlertController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        [HttpGet]
        [Route("GetAlertById")]
        public AlertBoundary GetAlertById(string alertId)
        {
            try
            {
                var alert = _alertService.GetAlertById(alertId);
                return alert;
            }
            catch (Exception)
            {
                throw new Exception("Faild to find alert by id");
            }
        }



       //Create Alert
        [HttpPost]
        [Route("CreateAlert")]
        public AlertBoundary CreateAlert(AlertBoundary alertBoundary)
        {
            try
            {
                var newAlert = _alertService.CreateAlert(alertBoundary);
                return newAlert;
            }
            catch (Exception)
            {
                throw new Exception("Failed to create new Alert");
            }
        }

    }
}

