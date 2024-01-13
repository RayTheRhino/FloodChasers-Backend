using FloodChasersModel.Boundaries.Learn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Learn.Service
{
    public interface ILearnService
    {
        public LearnBoundary GetArticleById(string learnId);
        public LearnBoundary CreateArticle(LearnBoundary learnBoundary);
        public List<LearnBoundary> GetAllArticles();
        public LearnBoundary UpdateArticle(LearnBoundary learnBoundary);
        public void DeleteArticleById(string learnId);
        public void DeleteAllArticles();
    }
}
