using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_dars
{
    public  class Post
    {
        public Guid Id { get; set; }
        public string OwnerName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime PostedTime { get; set; }
        public int QuantityLikes { get; set; }
        public List<string> Comment { get; set; } = new List<string>();
        public List<string> ViewersName { get; set; } = new List<string>();
        public int ViewersCount { get; set;}


    }
}
