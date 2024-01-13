using FloodChasersModel.Boundaries.Comments;
using FloodChasersModel.Comments;
using FloodChasersModel.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Boundaries.Posts
{
    public class PostBoundary
    {
        public string? Id { get; set; } 
        public ImageData ImageData { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public DateTime TimeCreated { get; set; }
        public List<CommentBoundary> Comments { get; set; } = new List<CommentBoundary>();
    }
}
