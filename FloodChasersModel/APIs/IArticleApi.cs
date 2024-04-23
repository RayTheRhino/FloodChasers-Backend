using FloodChasersModel.Boundaries.Learn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.APIs
{
    public interface IArticleApi
    {
        public Task<List<LearnBoundary>> GetArticlesBySubject(string subject);
    }
}
