using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Domain
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public List<Blog> blogs { get; set; }
        public List<PostTag> posttags { get; set; }
    }
}
