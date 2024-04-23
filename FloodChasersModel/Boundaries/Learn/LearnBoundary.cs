using FloodChasersModel.Comments;
using FloodChasersModel.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Boundaries.Learn
{
    public class LearnBoundary
    {
       // public string Id { get; set; } 

        public string UrlToImage { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Url { get; set; }
    }
}
