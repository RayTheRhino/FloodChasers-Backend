using FloodChasersLogic.Comments.Services;
using FloodChasersModel.Boundaries.Comments;
using FloodChasersModel.Boundaries.Posts;
using FloodChasersModel.Posts.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloodChasersAPI.Controllers
{
    [ApiController]
    [Route("Posts")]
    public class PostController : ControllerBase
    {
        private IPostService _postService;
        
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [Route("GetPostById")]
        public PostBoundary GetPostById(string postId)
        {
            try
            {
                var post = _postService.GetPostById(postId);
                return post;
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [Route("CreatePost")]
        public PostBoundary CreateComment(PostBoundary postBoundary)
        {
            try
            {
                var newPost = _postService.CreatePost(postBoundary);
                return newPost;
            }
            catch (Exception)
            {
                throw new Exception("Failed to create new Post");
            }
        }

        [HttpPost]
        [Route("AddCommentToPost")]
        public PostBoundary AddCommentToPost(CommentBoundary commentBoundary, string postId)
        {
            try
            {
                var newPost = _postService.AddCommentToPost(commentBoundary, postId);
                return newPost;
            }
            catch (Exception)
            {
                throw new Exception("Failed to add comment to comment");
            }
        }

        [HttpGet]
        [Route("GetAllPosts")]
        public List<PostBoundary> GetPosts()
        {
            try
            {
                var allPosts = _postService.GetAllPosts();
                return allPosts;
            }
            catch (Exception) { throw; }
        }

        [HttpPut]
        [Route("UpdatePost")]
        public PostBoundary UpdatePost(PostBoundary postBoundary)
        {
            try
            {
                var updatedPost = _postService.UpdatePost(postBoundary);
                return updatedPost;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeletePostById")]
        public void DeletePostById(string postId)
        {
            try
            {
                _postService.DeletePostById(postId);
            }
            catch (Exception)
            {
                throw new Exception("Could not delete Post by id");
            }
        }

        [HttpDelete]
        [Route("DeleteAllPosts")]
        public void DeleteAllPots()
        {
            try
            {
                _postService.DeleteAllPosts();

            }
            catch (Exception)
            {
                throw new Exception("Could not delete all Posts");
            }
        }
    }
}

