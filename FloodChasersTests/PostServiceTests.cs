using FloodChasersLogic.Alerts.Services;
using FloodChasersLogic.APIs;
using FloodChasersLogic.Dao;
using FloodChasersLogic.Forums.Services;
using FloodChasersLogic.Posts.Services;
using FloodChasersModel.Alerts;
using FloodChasersModel.Alerts.Services;
using FloodChasersModel.APIs;
using FloodChasersModel.Boundaries.Alerts;
using FloodChasersModel.Commons;
using FloodChasersModel.Forums;
using FloodChasersModel.Posts;
using FloodChasersModel.Posts.Services;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using Unity;

namespace FloodChasersTests
{
    [TestFixture]
    public class PostServiceTests
    {
        private IPostService _postService;
        private string connectionString = "mongodb://localhost:27017";
        private MongoClient _testClient;
        //private Mock<IPostService> _alertApiMock;


        [OneTimeSetUp]
        public void SetUp()
        {
            _testClient = new MongoClient(connectionString);
            //_postService = new PostService(new GenericDao<Post>(_testClient));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var database = _testClient.GetDatabase("FloodChasers");
            database.DropCollection(typeof(Alert).Name);
        }

       

    }
}
