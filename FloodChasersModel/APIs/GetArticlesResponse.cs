using FloodChasersModel.Boundaries.Learn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.APIs
{
    public class GetArticlesResponse
    {
        public string Status {  get; set; }
        public int TotalResults { get; set; }
        public List<LearnBoundary> Articles { get; set; }
    }
}
