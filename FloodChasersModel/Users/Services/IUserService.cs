using FloodChasersModel.Boundaries.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Users.Services
{
    public interface IUserService
    {
        public UserBoundary CreateUser(UserBoundary userBoundary, string password);
        public void DeleteUserById(string userId);

        public void DeleteAllUsers();

        public UserBoundary GetUserById(string userId);

        public List<UserBoundary> GetAllUsers();

        public UserBoundary UpdateUser(UserBoundary userBoundary);

        public UserBoundary TryLogin(string email,string password);
       
    }
}
