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
        public UserBoundary GetUserById(string userId);
        public UserBoundary CreateUser (UserBoundary userBoundary, string password);
    }
}
