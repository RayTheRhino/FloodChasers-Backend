using FloodChasersModel.Boundaries.Learn;
using FloodChasersModel.Dao;
using FloodChasersModel.Learn;
using FloodChasersModel.Learn.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersLogic.Learn.Service
{
    public class LearnService : ILearnService
    {
        private IGenericDeo<FloodChasersModel.Learn.Learn> _learnDao;
        public LearnService(IGenericDeo<FloodChasersModel.Learn.Learn> learnDao)
        {
            _learnDao = learnDao;
        }

        public LearnBoundary CreateArticle(LearnBoundary learnBoundary)
        {
            try
            {
                var learn = new FloodChasersModel.Learn.Learn
                {
                    Author = learnBoundary.Author,
                    Content = learnBoundary.Content,
                    ImageData = learnBoundary.ImageData,
                    TimeCreated = learnBoundary.TimeCreated,
                    Title = learnBoundary.Title,
                    //Add comments list , imgae is good ?
                };
                _learnDao.Add(learn);
                learnBoundary.Id = learn.Id;
                return (learnBoundary);
            }catch (Exception) { throw; }
        }

        public void DeleteAllArticles()
        {
            try
            {
                _learnDao.DeleteAll();
                return;
            }catch(Exception) { throw; }
        }

        public void DeleteArticleById(string learnId)
        {
            try
            {
                _learnDao.Delete(learnId);
                return;
            }catch(Exception) { throw; }
        }

        public List<LearnBoundary> GetAllArticles()
            
        {
            try
            {
                var articles = _learnDao.GetAll();
                var articleBoundaries = new List<LearnBoundary>();
                foreach(var article in articles)
                {
                    articleBoundaries.Add(new LearnBoundary
                    {
                        Author= article.Author,
                        Content= article.Content,
                        ImageData= article.ImageData,
                        TimeCreated = article.TimeCreated,
                        Title = article.Title,
                        //Add comments

                    });
                }
                return articleBoundaries;
            }catch(Exception) { throw; }
        }

        public LearnBoundary GetArticleById(string learnId)
        {
            try
            {
                var learn = _learnDao.GetById(learnId);
                if(learn == null)
                {
                    throw new Exception("Article was not found");
                }
                return new LearnBoundary
                {
                    Author = learn.Author,
                    Content = learn.Content,
                    ImageData = learn.ImageData,
                    TimeCreated = learn.TimeCreated,
                    Title = learn.Title,
                    //Add comments
                };
            }catch (Exception) { throw; }
        }

        public LearnBoundary UpdateArticle(LearnBoundary learnBoundary)
        {
            try
            {
                var exsistingArtilce = _learnDao.GetById(learnBoundary.Id);
                if(exsistingArtilce == null)
                {
                    throw new Exception("Article was not found");
                }
                exsistingArtilce.Author = learnBoundary.Author;
                exsistingArtilce.TimeCreated = learnBoundary.TimeCreated;
                exsistingArtilce.Content = learnBoundary.Content;
                exsistingArtilce.Title = learnBoundary.Title;
                //Comment and Image needs to be added
                _learnDao.Update(exsistingArtilce);
                return learnBoundary;
            }catch(Exception) { throw; }
        }
    }
}
