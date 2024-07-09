using FloodChasersModel.Comments;
using FloodChasersModel.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Boundaries.Comments
{
    public class CommentBoundary
    {
        public string? Id { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public string Body { get; set; }
        public string Title { get; set; }
        //public ImageData CommentImage { get; set; }
    }
}
