using FloodChasersModel.Boundaries.Users;
using FloodChasersModel.Dao;
using FloodChasersModel.Users;
using FloodChasersModel.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersLogic.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericDeo<User> _userDao;
        public UserService(IGenericDeo<User> userDao)
        {
            _userDao = userDao;
        }
        public UserBoundary CreateUser(UserBoundary userBoundary, string password)
        {
            try
            {
                var user = new User
                {
                    Email = userBoundary.Email,
                    FirstName = userBoundary.FirstName,
                    LastName = userBoundary.LastName,
                    ProfileImage = userBoundary.ProfileImage,
                    Password = password,
                };
                _userDao.Add(user);
                userBoundary.Id = user.Id;
                return userBoundary;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserBoundary GetUserById(string userId)
        {
            try
            {
                var user = _userDao.GetById(userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                return new UserBoundary
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Id = user.Id,
                    //Add image maybe
                };
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
