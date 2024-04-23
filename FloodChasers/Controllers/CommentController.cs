using FloodChasersModel.Boundaries.Comments;
using FloodChasersModel.Boundaries.Forum;
using FloodChasersModel.Comments.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloodChasersAPI.Controllers
{
    [ApiController]
    [Route("Comments")]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("GetCommnetById")]
        public CommentBoundary GetCommentById(string commentId)
        {
            try
            {
                var commnet = _commentService.GetCommentById(commentId);
                return commnet;

            }catch(Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("CreateComment")]
        public CommentBoundary CreateComment(CommentBoundary commentBoundary)
        {
            try
            {
                var newComment = _commentService.CreateComment(commentBoundary);
                return newComment;
            }
            catch (Exception)
            {
                throw new Exception("Failed to create new Comment");
            }
        }

        [HttpPost]
        [Route("AddCommentToComment")]
        public CommentBoundary AddCommentToComment(CommentBoundary commentBoundary, string commentParentId)
        {
            try
            {
                var newComment = _commentService.AddCommentToComment(commentBoundary,commentParentId);
                return newComment;
            }
            catch (Exception)
            {
                throw new Exception("Failed to add comment to comment");
            }
        }

        [HttpGet]
        [Route("GetAllComments")]
        public List<CommentBoundary> GetComments()
        {
            try
            {
                var allComments = _commentService.GetAllComments();
                return allComments;
            }
            catch (Exception) { throw; }
        }

        [HttpPut]
        [Route("UpdateComment")]
        public CommentBoundary UpdateComment(CommentBoundary commentBoundary)
        {
            try
            {
                var updatedComment = _commentService.UpdateComment(commentBoundary);
                return updatedComment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteCommentById")]
        public void DeleteCommentById(string commentId)
        {
            try
            {
                _commentService.DeleteCommentById(commentId);
            }
            catch (Exception)
            {
                throw new Exception("Could not delete Comment by id");
            }
        }

        [HttpDelete]
        [Route("DeleteAllComments")]
        public void DeleteAllComments()
        {
            try
            {
                _commentService.DeleteAllComments();

            }
            catch (Exception)
            {
                throw new Exception("Could not delete all Comments");
            }
        }
    }
}
