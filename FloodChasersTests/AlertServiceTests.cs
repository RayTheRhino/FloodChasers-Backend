using FloodChasersLogic.Alerts.Services;
using FloodChasersLogic.APIs;
using FloodChasersModel.Alerts;
using FloodChasersModel.Alerts.Services;
using FloodChasersModel.APIs;
using FloodChasersModel.Boundaries.Alerts;
using FloodChasersModel.Commons;
using MongoDB.Driver;
using Moq;
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
        private Mock<IAlertApi> _alertApiMock;


        [OneTimeSetUp]
        public void SetUp()
        {
            _testClient = new MongoClient(connectionString);
            _alertApiMock = new Mock<IAlertApi>();
            _alertService = new AlertService(_alertApiMock.Object);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var database = _testClient.GetDatabase("FloodChasers");
            database.DropCollection(typeof(Alert).Name);
        }

        [Test]
        public async Task GetAllAlertsTest_ShouldReturn1Alert()
        {
            //arrange
            var valueToReturn = new List<AlertBoundary> 
            { 
                new AlertBoundary
                {
                    Headline = "Alert"
                }
            };
            _alertApiMock.Setup(x => x.GetAllAlerts()).ReturnsAsync(valueToReturn);

            //act
            var alerts = await _alertService.GetAllAlerts();

            //assert
            Assert.That(alerts, Is.Not.Null);
            Assert.That(alerts.Count, Is.EqualTo(1));
        }
        [Test]
        public async Task GetAllAlerts_WhenNoAlerts_ShouldReturnEmptyList()
        {
            //arrange
            var valueToReturn = new List<AlertBoundary>();
            _alertApiMock.Setup(x => x.GetAllAlerts()).ReturnsAsync(valueToReturn);

            //act
            var alerts = await _alertService.GetAllAlerts();

            //assert
            Assert.That(alerts, Is.Not.Null);
            Assert.That(alerts.Count, Is.EqualTo(0));
        }
       

    }
}
