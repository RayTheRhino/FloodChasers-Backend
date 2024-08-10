using FloodChasersLogic.Alerts.Services;
using FloodChasersLogic.Dao;
using FloodChasersLogic.Users.Services;
using FloodChasersModel.Alerts;
using FloodChasersModel.APIs;
using FloodChasersModel.Boundaries.Users;
using FloodChasersModel.Users;
using FloodChasersModel.Users.Services;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserService _userService;
        private string connectionString = "mongodb://localhost:27017";
        private MongoClient _testClient;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testClient = new MongoClient(connectionString);
            _userService = new UserService(new GenericDao<User>(_testClient));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            var database = _testClient.GetDatabase("FloodChasers");
            database.DropCollection(typeof(Alert).Name);
        }

        [Test]
        public async Task CreateUser_ShouldReturnCreatedUser()
        {
            //arrange data
            var user = new UserBoundary
            {
                Email = "test@gmail.com",
                UserName = "Test",
            };

            //act
            var responseUser = _userService.CreateUser(user, "123");
            
            //assert
            Assert.That(responseUser, Is.Not.Null);
            Assert.That(responseUser, Is.EqualTo(user));
        }
        [Test]
        public void GetUserByID_ShouldReturnUser_WhenUserExsits()
        {
            //arrange 
            var userBoundary = new UserBoundary
            {
                Email = "test@gmail.com",
                UserName = "Test"
            };
            
            var createdUser = _userService.CreateUser(userBoundary, "123");

            //act
            var responseUser = _userService.GetUserById(createdUser.Id);

            //assert
            Assert.That(responseUser, Is.Not.Null);
            Assert.That(responseUser.Id, Is.EqualTo(createdUser.Id));
            Assert.That(responseUser.UserName, Is.EqualTo(createdUser.UserName));
            Assert.That(responseUser.Email, Is.EqualTo(createdUser.Email));
        }

        [Test]
        public void UpdateUser_ShouldReturnUpdatedUser()
        {
            //arrange
            var userBoundary = new UserBoundary
            {
                Email = "test@gmail.com",
                UserName = "Test"
            };

            var createdUser = _userService.CreateUser(userBoundary, "123");
            createdUser.UserName = "UpdatedTest3";

            //act
            var updatedUser = _userService.UpdateUser(createdUser);

            //assert
            Assert.That(updatedUser, Is.Not.Null);
            Assert.That(updatedUser.UserName,Is.EqualTo("UpdatedTest3"));
         
        }

        [Test]
        public void DeleteUser_ShouldRemoveDeletedUser() 
        {
            //arrange
            var userBoundary = new UserBoundary
            {
                Email = "test@gmail.com",
                UserName = "Test"
            };
            var createdUser = _userService.CreateUser(userBoundary, "123");

            //act
            _userService.DeleteUserById(createdUser.Id);
            var responseUser = _userService.GetUserById(createdUser.Id);


            //assert
            Assert.That(responseUser, Is.Null);
        }

        [Test]
        public void DeleteAllUsers_ShouldRemoveAllUsers()
        {
            // Arrange
            var userBoundary = new UserBoundary
            {
                Email = "test@gmail.com",
                UserName = "Test"
            };

            var userBoundary2 = new UserBoundary
            {
                Email = "test6@gmail.com",
                UserName = "Test6",
            };

            _userService.CreateUser(userBoundary, "123");
            _userService.CreateUser(userBoundary2, "132");

            // Act
            _userService.DeleteAllUsers();
            var allUsers = _userService.GetAllUsers();

            // Assert
            Assert.That(allUsers, Is.Empty);
        }

        [Test]
        public void Login_ShouldReturnUser_WhenCredentialsAreCorrect()
        {
            // Arrange
            var userBoundary = new UserBoundary
            {
                Email = "test@gmail.com",
                UserName = "Test"
            };
            var createdUser = _userService.CreateUser(userBoundary, "correctpassword");

            // Act
            var loggedInUser = _userService.TryLogin("test@gmail.com", "correctpassword");

            // Assert
            Assert.That(loggedInUser, Is.Not.Null);
            Assert.That(loggedInUser.Id, Is.EqualTo(createdUser.Id));
        }

        [Test]
        public void Login_ShouldReturnNull_WhenCredentialsAreIncorrect()
        {
            // Arrange
            var userBoundary = new UserBoundary
            {
                Email = "test@gmail.com",
                UserName = "Test"
            };
            _userService.CreateUser(userBoundary, "correctpassword");

            // Act
            var loggedInUser = _userService.TryLogin("test8@gmail.com", "wrongpassword");

            // Assert
            Assert.That(loggedInUser, Is.Null);
        }
    }
}
