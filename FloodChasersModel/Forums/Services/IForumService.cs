using FloodChasersModel.Boundaries.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Forums.Services
{
    public interface IForumService
    {
        public ForumBoundary GetForumById(string forumId);

        public ForumBoundary CreateForum(ForumBoundary froumBoundary);
        public void DeleteForumById(string userId);

        public void DeleteAlForums();


        public List<ForumBoundary> GetAllForums();

        public ForumBoundary UpdateForum(ForumBoundary froumBoundary);
    }
}
