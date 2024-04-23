using FloodChasersAPI.Data.Common;
using FloodChasersModel.Boundaries.Alerts;
using FloodChasersModel.Boundaries.Forum;
using FloodChasersModel.Forums.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloodChasersAPI.Controllers
{
    [ApiController]
    [Route("Forums")]
    public class ForumController : ControllerBase
    {
        public IForumService _forumService;
        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet]
        [Route("GetForumById")]
        public FroumBoundary GetForumById(string ForumId)
        {
            try
            {
                var forum = _forumService.GetForumById(ForumId);
                return forum;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("CreateForum")]
        public FroumBoundary CreateForum(FroumBoundary forumBoundary)
        {
            try
            {
                var newForum = _forumService.CreateForum(forumBoundary);
                return newForum;
            }
            catch (Exception)
            {
                throw new Exception("Failed to create new Forum");
            }
        }

        [HttpPost]
        [Route("GetAllForums")]
        public List<FroumBoundary> GetForums()
        {
            try
            {
                var allFroums = _forumService.GetAllForums();
                return allFroums;
            }
            catch (Exception) { throw; }
        }

        [HttpPut]
        [Route("UpdateForum")]
        public FroumBoundary UpdateForum( FroumBoundary forumBoundary)
        {
            try
            {
                var updatedFroum = _forumService.UpdateForum(forumBoundary);
                return updatedFroum;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteForumById")]
        public void DeleteForumById(string forumId)
        {
            try
            {
                _forumService.DeleteForumById(forumId);
            }
            catch (Exception)
            {
                throw new Exception("Could not delete Forum by id");
            }
        }

        [HttpDelete]
        [Route("DeleteAllForums")]
        public void DeleteAllForums()
        {
            try
            {
                _forumService.DeleteAlForums();

            }
            catch (Exception)
            {
                throw new Exception("Could not delete all Forums");
            }
        }
    }
}

