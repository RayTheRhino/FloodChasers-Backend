using FloodChasersLogic.Alerts.Services;
using FloodChasersLogic.Dao;
using FloodChasersModel.Alerts;
using FloodChasersModel.Alerts.Services;
using FloodChasersModel.Boundaries.Alerts;
using FloodChasersModel.Commons;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Unity;

namespace FloodChasersTests
{
    [TestFixture]
    public class AlertServiceTests
    {
        private IAlertService _alertService;
        private string connectionString = "Data Source=RAYTHERHINO;Initial Catalog=FloodChasersDb;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False";


        [OneTimeSetUp]
        public void SetUp()
        {
            _alertService = new AlertService(new GenericDao<Alert>(new AppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext>(UseSqlServer(connectionString)))));
             
            //Initialize the service
           //var unityContainer = new UnityContainer();
           // unityContainer.RegisterType<IAlertService,AlertService>();
           // _alertService = unityContainer.Resolve<IAlertService>();
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
