using NUnit.Framework;
using Moq;
using FloodChasersLogic.Comments.Services;
using FloodChasersModel.Boundaries.Comments;
using FloodChasersModel.Comments;

using NUnit.Framework.Legacy;
using FloodChasersModel.Dao;


namespace FloodChasersTests
{
    [TestFixture]
    public class CommentServiceTests
    {
        private Mock<IGenericDao<Comment>>? mockCommentDao;
        private CommentService? commentService;

        [OneTimeSetUp]
        public void SetUp()
        {
            mockCommentDao = new Mock<IGenericDao<Comment>>();
            commentService = new CommentService(mockCommentDao.Object);
        }
        [Test]
        public void Test_CreateComment()
        {
            var result = commentService?.CreateComment(new CommentBoundary { Id = "1", Title = "Commnet1" });
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual("Commnet1", result?.Title);
        }

        [Test]
        public void Test_GetAllComments()
        {
            var commentBoundary = commentService?.CreateComment(new CommentBoundary { Id = "1", Title = "comment1" });
            var commentBoundary2 = commentService?.CreateComment(new CommentBoundary { Id = "2", Title = "comment2" });

            var comments = new List<Comment>
            {
                new() { Id = "1", Title = "comment1" },
                new() { Id = "2", Title = "comment2" }
            };

            mockCommentDao?.Setup(dao => dao.GetAll()).Returns(comments.AsQueryable());
            var result = commentService?.GetAllComments();
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(comments.Count, result?.Count);
        }

        [Test]
        public void Test_DeleteAllComments()
        {
            commentService?.DeleteAllComments();
            mockCommentDao?.Verify(dao => dao.DeleteAll(), Times.Once);
        }
    }
}