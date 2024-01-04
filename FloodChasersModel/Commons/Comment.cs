using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Commons
{
    public class Comment
    {
        public int Id { get; set; }
        public Metadata Metadata { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public ImageData ImageData { get; set; }
        public List<Comment> Comments { get; set;} = new List<Comment>();
    }
}
