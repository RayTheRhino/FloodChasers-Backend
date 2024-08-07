﻿using FloodChasersModel.Boundaries.Users;
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
        private readonly IGenericDao<User> _userDao;
        public UserService(IGenericDao<User> userDao)
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
                    UserName = userBoundary.UserName,
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

        public void DeleteUserById(string userId)
        {
            try
            {
                _userDao.Delete(userId);
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteAllUsers()
        {
            try
            {
                _userDao.DeleteAll();
                return;
            }
            catch(Exception) { throw; }
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
                    UserName = user.UserName,
                    Id = user.Id,
                    //Add image maybe
                };
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<UserBoundary> GetAllUsers()
        {
            try
            {
                var users = _userDao.GetAll();
                var userBoundaries = new List<UserBoundary>();
                foreach (var user in users)
                {
                    userBoundaries.Add(new UserBoundary
                    {
                        Email = user.Email,
                        UserName = user.UserName,
                        Id = user.Id,
                        //Add image
                    });
                }
                return userBoundaries;
            }
            catch (Exception) { throw; }
        }
        public UserBoundary UpdateUser(UserBoundary userBoundary)
        {
            try
            {
                var exsistingUser = _userDao.GetById(userBoundary.Id);
                if(exsistingUser == null)
                {
                    throw new Exception("User was not found");
                }
                exsistingUser.UserName = userBoundary.UserName;
                exsistingUser.Email = userBoundary.Email;
                //pofile image and password
                _userDao.Update(exsistingUser);
                return userBoundary;
            }
            catch(Exception) { throw; }
        }

        public UserBoundary TryLogin(string email, string password)
        {
            try
            {
                var user = _userDao.GetByField("Email", email);
                if (user == null)
                {
                    throw new Exception("Email does not exists");
                }
                if (string.IsNullOrEmpty(password) || !password.Equals(user.Password))
                {
                    throw new Exception("Incorrect password");
                }
                return new UserBoundary
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Id = user.Id,
                    //Add image maybe
                };
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}
