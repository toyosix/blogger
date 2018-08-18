using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Domain
{
    public class Blog
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Post> posts { get; set; }
        public User user { get; set; }
        public int user_id { get; set; }
    }
}
