using FloodChasersModel.Boundaries.Forum;
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
    internal class ForumService : IForumService
    {
        private IGenericDeo<Forum> _forumDao;
        public ForumService(IGenericDeo<Forum> forumDao)
        {
            _forumDao = forumDao;
        }
        public FroumBoundary CreateForum(FroumBoundary froumBoundary)
        {
            try
            {
                var forum = new Forum
                {
                    Posts = froumBoundary.Posts
                };
                _forumDao.Add(forum);
                froumBoundary.Id = forum.Id;
                return froumBoundary;
            }catch (Exception ) 
            {
                throw;
            }
        }

        public FroumBoundary GetForumById(string forumId)
        {
            try
            {
                var forum = _forumDao.GetById(forumId);
                if (forum == null)
                {
                    throw new Exception("Forum was not found");
                }
                return new FroumBoundary
                {
                    Posts = forum.Posts,
                    Id = forum.Id
                };
            }
            catch (Exception )
            {
                throw;
            }
            
        }
    }
}
