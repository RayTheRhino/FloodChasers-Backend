using FloodChasersModel.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Forums
{
    [Table("Forums")]
    public class Forum
    {
        [Key]
        public string Id { get; set; }
        public List<Post> Posts { get; set; }

    }
}
