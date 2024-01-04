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
        public FroumBoundary GetForumById(string forumId);

        public FroumBoundary CreateForum(FroumBoundary froumBoundary);
    }
}
