using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloodChasersModel.Commons;

namespace FloodChasersModel.Comments
{
    public class Comment
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public string Body { get; set; }
        public string Title { get; set; }
        public ImageData? CommentImage { get; set; }
        public List<string> CommentsIds { get; set; } = new List<string>();
    }
}
