using FloodChasersAPI.Data.Common;
using FloodChasersAPI.Data.Users;
using FloodChasersModel.Boundaries.Users;
using FloodChasersModel.Commons;
using FloodChasersModel.Users;
using FloodChasersModel.Users.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Reflection;

namespace FloodChasersAPI.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetUserById")]
        public UserBoundary GetUserById(string userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("CreateUser")]
        public UserBoundary CreateUser([FromForm] FileUploadModel request)
        {
            try
            {
                // Access JSON data
                CreateUserRequest createUserRequest = JsonConvert.DeserializeObject<CreateUserRequest>(request.JsonData);
                var userBoundary = new UserBoundary
                {
                    Email = createUserRequest.Email,
                    FirstName = createUserRequest.FirstName,
                    LastName = createUserRequest.LastName,
                    //Add image later
                };
                var newUser = _userService.CreateUser(userBoundary, createUserRequest.Password);
                return newUser;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
