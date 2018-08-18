using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blogger.Domain
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public Blog blog { get; set; }
        public List<Comment> comments { get; set; }
        [ForeignKey("BlogId")]
        public int blog_id { get; set; }
        public List<PostTag> posttags { get; set; }
    }
}
