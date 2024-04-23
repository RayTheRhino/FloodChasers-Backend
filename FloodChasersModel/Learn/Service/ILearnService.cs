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
        public Task<List<LearnBoundary>> GetAllArticles();
        
    }
}
