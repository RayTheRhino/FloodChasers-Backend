using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloodChasersModel.Comments;
using FloodChasersModel.Commons;

namespace FloodChasersModel.Posts
{
    public class Post
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public ImageData? ImageData { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public List<string> CommentsIds  { get; set; } = new List<string>();

    }
}
