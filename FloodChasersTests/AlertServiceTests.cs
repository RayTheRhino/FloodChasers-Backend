using FloodChasersLogic.Alerts.Services;
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
            _alertService = new AlertService(new GenericDao<Alert>(_testClient));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var database = _testClient.GetDatabase("FloodChasers");
            database.DropCollection(typeof(Alert).Name);
        }

        [Test]
        public void CreateAlertTest()
        {
            //arrange 
            var alertBoundary = new AlertBoundary
            {
                Headline = "Headline",
                Location = new Location
                {
                    Latitude = 30.5,
                    Longitude = 32
                },
                Description = "Description",
                TimeCreated = DateTime.Now,
            };

            //act 
            var alertCreated = _alertService.CreateAlert(alertBoundary);

            //Assert
            Assert.That(alertCreated, Is.Not.Null);
            Assert.That(alertCreated.Id, Is.Not.Null);
            Assert.That(alertCreated.Headline, Is.EqualTo(alertBoundary.Headline));
        }



    }
}
