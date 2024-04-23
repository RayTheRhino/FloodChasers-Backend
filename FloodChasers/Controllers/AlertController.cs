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
        public async Task<ActionResult<List<AlertBoundary>>> GetAlertsByLocation(string city, double? lat, double? lon)
        {
            try
            {
                if (city == null && (!lat.HasValue || !lon.HasValue))
                {
                    return BadRequest("location is missing");
                }
                var location = new Location
                {
                    City = city,
                    Latitude = lat.HasValue? lat.Value : 0,
                    Longitude = lon.HasValue ? lat.Value : 0
                };
                var allAlerts = await _alertService.GetAllAlerts(location);
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

