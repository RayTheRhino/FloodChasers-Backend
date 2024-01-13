using FloodChasersModel.Boundaries.Comments;
using FloodChasersModel.Boundaries.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Posts.Services
{
    public interface IPostService
    {
        public PostBoundary GetPostById(string postId);
        public PostBoundary CreatePost(PostBoundary postBoundary);
        public List<PostBoundary> GetAllPosts();
        public PostBoundary UpdatePost(PostBoundary postBoundary);
        public PostBoundary AddCommentToPost(CommentBoundary commentBoundary,string postId);
        public void DeletePostById(string postId);
        public void DeleteAllPosts();
    }
}
