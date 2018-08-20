using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blogger.Domain
{
    public class Post
    {
        public Post()
        {
            List<Tag> tags = new List<Tag>();
        }

        public int id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public virtual Blog blog { get; set; }
        public virtual List<Comment> comments { get; set; } // lazy loading
        public int blog_id { get; set; }
        [NotMapped]
        public virtual List<Tag> tags { get; set; }
    }
}
