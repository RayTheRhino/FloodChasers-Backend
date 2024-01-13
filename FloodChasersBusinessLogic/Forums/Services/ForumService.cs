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
    public class ForumService : IForumService
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

        public List<FroumBoundary> GetAllForums()
        {
            try
            {
                var forums = _forumDao.GetAll();
                var forumBoundaries = new List<FroumBoundary>();
                foreach(var forum in forums)
                {
                    forumBoundaries.Add(new FroumBoundary
                    {
                        Id = forum.Id,
                        Posts = forum.Posts
                    });
                }
                return forumBoundaries;
            }catch (Exception) { throw; }
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

        public FroumBoundary UpdateForum(FroumBoundary froumBoundary)
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
