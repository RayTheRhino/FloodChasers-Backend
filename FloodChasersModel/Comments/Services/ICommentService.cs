using FloodChasersModel.Boundaries.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Comments.Services
{
    public interface ICommentService
    {
        public CommentBoundary GetCommentById(string commentId);

        public  CommentBoundary CreateComment(CommentBoundary commentBoundary);

        public List<CommentBoundary> GetAllComments();

        public CommentBoundary UpdateComment(CommentBoundary commentBoundary);

        public CommentBoundary AddCommentToComment(CommentBoundary commentBoundary, string commentId);

        public void DeleteCommentById(string commentId);

        public void DeleteAllComments();
    }
}
