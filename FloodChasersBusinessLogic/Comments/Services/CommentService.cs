using FloodChasersLogic.Posts.Services;
using FloodChasersModel.Boundaries.Comments;
using FloodChasersModel.Boundaries.Posts;
using FloodChasersModel.Comments;
using FloodChasersModel.Comments.Services;
using FloodChasersModel.Dao;
using FloodChasersModel.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersLogic.Comments.Services
{
    public class CommentService : ICommentService
    {
        private IGenericDeo<Comment> _commentDao;

        public CommentService(IGenericDeo<Comment> commentDao) 
        {
            _commentDao = commentDao; 
        }
        public CommentBoundary CreateComment(CommentBoundary commentBoundary)
        {
            try
            {
                var comment = ToEntity(commentBoundary);
                _commentDao.Add(comment);
                 commentBoundary.Id = comment.Id;
                return commentBoundary;
            }catch (Exception) { throw; }
        }

        public void DeleteAllComments()
        {
            try
            {
                _commentDao.DeleteAll();
                return;
            }catch(Exception) { throw; }
        }

        public void DeleteCommentById(string commentId)
        {
            try
            {
                _commentDao.Delete(commentId);
                return;
            }catch (Exception) { throw ; }
        }

        public List<CommentBoundary> GetAllComments()
        {
            try
            {
                var comments = _commentDao.GetAll();
                var commentBoundaries = new List<CommentBoundary>();
                foreach (var comment in comments)
                {
                    commentBoundaries.Add(ToBoundary(comment));
                }
                return commentBoundaries;
            }catch (Exception) { throw; }
            
        }

        public CommentBoundary GetCommentById(string commentId)
        {
            try
            {
                var comment = _commentDao.GetById(commentId);
                if(comment == null)
                {
                    throw new Exception("Comment not found");
                }
                return ToBoundary(comment);
            }catch (Exception) { throw; }
        }

        public CommentBoundary UpdateComment(CommentBoundary commentBoundary)
        {
            try
            {
                var comment = ToEntity(commentBoundary);
                comment.Id = commentBoundary.Id;
                _commentDao.Update(comment);
                return commentBoundary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private CommentBoundary ToBoundary(Comment comment)
        {
            var boundary = new CommentBoundary();
            boundary.Body = comment.Body;
            boundary.TimeCreated = comment.TimeCreated;
            boundary.Title = comment.Title;
            //boundary.CommentImage = comment.CommentImage;
            boundary.Id = comment.Id;
            return boundary;

        }

        private List<CommentBoundary> GetCommentsById(List<string> commentsIds)
        {
            var comments = new List<CommentBoundary>();
            foreach (var commentId in commentsIds)
            {
                comments.Add(ToBoundary(_commentDao.GetById(commentId)));
            }
            return comments;
        }

        private Comment ToEntity(CommentBoundary boundary)
        {
            var entity = new Comment
            {
                Title = boundary.Title,
                Body = boundary.Body,
                TimeCreated = boundary.TimeCreated,
                //CommentImage = boundary.CommentImage,
            };
            return entity;

        }

        public CommentBoundary AddCommentToComment(CommentBoundary newCommentBoundary, string commentId)
        {
            try
            {
                var commentParent = _commentDao.GetById(commentId);
                if (commentParent == null)
                {
                    throw new Exception($"Comment with id: {commentId} does not exists");
                }
                var newCommentWithId = CreateComment(newCommentBoundary);
                _commentDao.Update(commentParent);
                return ToBoundary(commentParent);

            }
            catch (Exception)
            {

                throw;
            }
        }
       

    }
}
