﻿using FloodChasersModel.Boundaries.Forum;
using FloodChasersModel.Dao;
using FloodChasersModel.Forums;
using FloodChasersModel.Forums.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersLogic.Forums.Services
{
    public class ForumService : IForumService
    {
        private IGenericDao<Forum> _forumDao;
        public ForumService(IGenericDao<Forum> forumDao)
        {
            _forumDao = forumDao;
        }
        public ForumBoundary CreateForum(ForumBoundary froumBoundary)
        {
            try
            {
                var forum = new Forum
                {
                    Posts = froumBoundary.Posts,
                    Name = froumBoundary.Name,
                };
                _forumDao.Add(forum);
                froumBoundary.Id = forum.Id;
                return froumBoundary;
            }catch (Exception ) 
            {
                throw;
            }
        }

        public void DeleteAlForums()
        {
            try
            {
                _forumDao.DeleteAll();
                return;
            }catch(Exception ) { throw; }
        }

        public void DeleteForumById(string forumId)
        {
            try
            {
                _forumDao.Delete(forumId);
                return;
            } catch (Exception ) { throw; }
        }

        public List<ForumBoundary> GetAllForums()
        {
            try
            {
                var forums = _forumDao.GetAll();
                var forumBoundaries = new List<ForumBoundary>();
                foreach(var forum in forums)
                {
                    forumBoundaries.Add(new ForumBoundary
                    {
                        Id = forum.Id,
                        Posts = forum.Posts,
                        Name = forum.Name,
                    });
                }
                return forumBoundaries;
            }catch (Exception) { throw; }
        }

        public ForumBoundary GetForumById(string forumId)
        {
            try
            {
                var forum = _forumDao.GetById(forumId);
                if (forum == null)
                {
                    throw new Exception("Forum was not found");
                }
                return new ForumBoundary
                {
                    Posts = forum.Posts,
                    Id = forum.Id,
                    Name = forum.Name

                };
            }
            catch (Exception )
            {
                throw;
            }
            
        }

        public ForumBoundary UpdateForum(ForumBoundary froumBoundary)
        {
            try
            {
                var exsitingFroum = _forumDao.GetById(froumBoundary.Id);
                if(exsitingFroum == null)
                {
                    throw new Exception("Forum was not found");
                }
                exsitingFroum.Posts = froumBoundary.Posts;
                _forumDao.Update(exsitingFroum);
                return froumBoundary;
            }catch (Exception) { throw; }
        }
    }
}
