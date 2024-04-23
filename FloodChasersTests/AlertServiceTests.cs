using FloodChasersLogic.Alerts.Services;
using FloodChasersLogic.APIs;
using FloodChasersLogic.Dao;
using FloodChasersModel.Alerts;
using FloodChasersModel.Alerts.Services;
using FloodChasersModel.Boundaries.Alerts;
using FloodChasersModel.Commons;
using MongoDB.Driver;
using NUnit.Framework;
using Unity;

namespace FloodChasersTests
{
    [TestFixture]
    public class AlertServiceTests
    {
        private IAlertService _alertService;
        private string connectionString = "mongodb://localhost:27017";
        private MongoClient _testClient;


        [OneTimeSetUp]
        public void SetUp()
        {
            _testClient = new MongoClient(connectionString);
            _alertService = new AlertService(new WeatherApi());
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var database = _testClient.GetDatabase("FloodChasers");
            database.DropCollection(typeof(Alert).Name);
        }

        [Test]
        public async Task GetAllAlertsForCity()
        {
            var location = new Location
            {
                City = "Rome"
            };
            var alerts = await _alertService.GetAllAlerts(location);
            Assert.That(alerts, Is.Not.Null);
        }



    }
}
