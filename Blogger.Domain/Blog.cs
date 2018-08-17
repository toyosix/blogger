using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Domain
{
    public class Blog
    {
        public int id { get; set; }
        public string name { get; set; }
        public Blogger blogger { get; set; }
        public int blogger_id { get; set; }
    }
}
