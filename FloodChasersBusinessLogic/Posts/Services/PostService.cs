using FloodChasersModel.Boundaries.Comments;
using FloodChasersModel.Boundaries.Posts;
using FloodChasersModel.Comments;
using FloodChasersModel.Comments.Services;
using FloodChasersModel.Dao;
using FloodChasersModel.Posts;
using FloodChasersModel.Posts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersLogic.Posts.Services
{
    public class PostService : IPostService
    {
        private IGenericDeo<Post> _postDao;
        private ICommentService _commentService;

        public PostService(ICommentService commentService, IGenericDeo<Post> postDao)
        {
            _commentService = commentService;
            _postDao = postDao;
        }

        public PostBoundary AddCommentToPost(CommentBoundary commentBoundary, string postId)
        {
            try
            {
                var post = _postDao.GetById(postId);
                if (post == null)
                {
                    throw new Exception($"Post {postId} does not exists");
                }
                var comment = _commentService.CreateComment(commentBoundary);
                post.CommentsIds.Add(comment.Id);
                _postDao.Update(post);
                return ToBoundary(post);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public PostBoundary CreatePost(PostBoundary postBoundary)
        {
            try
            {
                var post = ToEntity(postBoundary);
                _postDao.Add(post);
                postBoundary.Id = post.Id;
                return postBoundary;
            }catch (Exception)
            {
                throw;
            }
        }

        public void DeleteAllPosts()
        {
            try
            {
                _postDao.DeleteAll();
                return;
            }catch(Exception) { throw; }
        }

        public void DeletePostById(string postId)
        {
            try
            {
                _postDao.Delete(postId);
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PostBoundary> GetAllPosts()
        {
            try
            {
                var posts = _postDao.GetAll();
                var postBoundaries = new List<PostBoundary>();
                foreach (var post in posts) {
                    postBoundaries.Add(ToBoundary(post));
                }
                return postBoundaries;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PostBoundary GetPostById(string postId)
        {
            try
            {
                var post = _postDao.GetById(postId);
                if(post == null)
                {
                    throw new Exception("Post was not Found");
                }
                return ToBoundary(post);
            }
            catch (Exception) { throw; }
        }

        public PostBoundary UpdatePost(PostBoundary postBoundary)
        {
            try
            {
                
                var post = ToEntity(postBoundary);
                post.Id = postBoundary.Id;
                _postDao.Update(post);
                return postBoundary;
            }
            catch(Exception) 
            { 
                throw; 
            }
        }

        public PostBoundary ToBoundary(Post post)
        {
            var boundary = new PostBoundary();
            boundary.Title = post.Title;
            boundary.Body = post.Body;
            boundary.TimeCreated = post.TimeCreated;
            boundary.Id = post.Id;
            boundary.Comments = GetCommentListForPost(post.CommentsIds);
            return boundary;

        }

        private List<CommentBoundary> GetCommentListForPost(List<string> commentsIds)
        {
            var comments = new List<CommentBoundary>();
            foreach (var commentId in commentsIds)
            {
                comments.Add(_commentService.GetCommentById(commentId));
            }
            return comments;
        }

        private Post ToEntity(PostBoundary boundary)
        {
            var entity = new Post
            {
                Title = boundary.Title,
                Body = boundary.Body,
                TimeCreated = boundary.TimeCreated,
                CommentsIds = boundary.Comments.Select(x => x.Id).ToList(),
                ImageData = boundary.ImageData,
            };
            return entity;

        }
    }
}
