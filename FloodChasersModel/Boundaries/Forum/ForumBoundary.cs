using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using FloodChasersModel.Posts;




namespace FloodChasersModel.Boundaries.Forum
{
    public class ForumBoundary
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
      
    }
}
