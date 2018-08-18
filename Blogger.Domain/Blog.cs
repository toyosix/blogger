using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Domain
{
    public class Blog
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<Post> posts { get; set; }
        public virtual User user { get; set; }
        public int user_id { get; set; }
    }
}
