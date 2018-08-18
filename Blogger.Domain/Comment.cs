using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Domain
{
    public class Comment
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string text { get; set; }
        public int post_id { get; set; }
        public virtual Post post { get; set; }
    }
}
