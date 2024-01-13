using FloodChasersModel.Boundaries.Learn;
using FloodChasersModel.Learn.Service;
using Microsoft.AspNetCore.Mvc;

namespace FloodChasersAPI.Controllers
{
    [ApiController]
    [Route("Articles")]
    public class LearnController : ControllerBase
    {
        private ILearnService _learnService;
        public LearnController(ILearnService learnService)
        {
            _learnService = learnService;
        }


        [HttpGet]
        [Route("GetArticleById")]
        public LearnBoundary GetArticleById(string learnId)
        {
            try
            {
                var article = _learnService.GetArticleById(learnId);
                return article;

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("CreateArticle")]
        public LearnBoundary CreateArticle(LearnBoundary learnBoundary)
        {
            try
            {
                var newArticle = _learnService.CreateArticle(learnBoundary);
                return newArticle;
            }
            catch (Exception)
            {
                throw new Exception("Failed to create new Article");
            }
        }

        [HttpPost]
        [Route("GetAllArticles")]
        public List<LearnBoundary> GetArticles()
        {
            try
            {
                var allArticles = _learnService.GetAllArticles();
                return allArticles;
            }
            catch (Exception) { throw; }
        }

        [HttpPut]
        [Route("UpdateArticle")]
        public LearnBoundary UpdateArticle(LearnBoundary learnBoundary)
        {
            try
            {
                var updatedArticle = _learnService.UpdateArticle(learnBoundary);
                return updatedArticle;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteArticleById")]
        public void DeleteArticleById(string learnId)
        {
            try
            {
               _learnService.DeleteArticleById(learnId);
            }
            catch (Exception)
            {
                throw new Exception("Could not delete Article by id");
            }
        }

        [HttpDelete]
        [Route("DeleteAllArticles")]
        public void DeleteAllArticles()
        {
            try
            {
                _learnService.DeleteAllArticles();

            }
            catch (Exception)
            {
                throw new Exception("Could not delete all Articles");
            }
        }
    }
}

