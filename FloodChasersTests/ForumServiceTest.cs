using FloodChasersLogic.Dao;
using FloodChasersLogic.Forums.Services;
using FloodChasersLogic.Users.Services;
using FloodChasersModel.Forums;
using FloodChasersModel.Forums.Services;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersTests
{
    [TestFixture]
    public class ForumServiceTest
    {
        private IForumService _forumService;
        private string connectionString = "mongodb://localhost:27017";
        private MongoClient _testClient;


        [OneTimeSetUp]
        public void SetUp()
        {
            _testClient = new MongoClient(connectionString);
            _forumService = new ForumService(new GenericDao<Forum>(_testClient));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var database = _testClient.GetDatabase("FloodChasers");
            database.DropCollection(typeof(Forum).Name);
        }


    }

}
