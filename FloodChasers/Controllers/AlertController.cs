using FloodChasersModel.Alerts.Services;
using FloodChasersModel.Boundaries.Alerts;
using FloodChasersModel.Boundaries.Learn;
using FloodChasersModel.Commons;
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
        [Route("GetAllAlerts")]
        public async Task<ActionResult<List<AlertBoundary>>> GetAllAlerts()
        {
            try
            {
                var allAlerts = await _alertService.GetAllAlerts();
                return Ok(allAlerts);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                throw; 
            }
        }


    }
}

