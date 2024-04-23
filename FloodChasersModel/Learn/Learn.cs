using FloodChasersModel.Comments;
using FloodChasersModel.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Learn
{
    public class Learn
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public ImageData? ImageData { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public List<Comment> Comments { get; set; }
    }
}
