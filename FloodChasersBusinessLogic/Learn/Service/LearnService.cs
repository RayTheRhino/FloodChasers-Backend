using FloodChasersModel.APIs;
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
        private IArticleApi _articleApi;
        public LearnService(IArticleApi articleApi)
        {
            _articleApi = articleApi;
        }

        public async Task<List<LearnBoundary>> GetAllArticles()
            
        {
            try
            {
                var articles = await _articleApi.GetArticlesBySubject("sustainability");
                return articles;
            }catch(Exception) { throw; }
        }
    }
}
