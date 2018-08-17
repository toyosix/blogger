using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Domain
{
    public class Blog
    {
        public int id { get; set; }
        public string name { get; set; }
        public User users { get; set; }
        public int user_id { get; set; }
    }
}
