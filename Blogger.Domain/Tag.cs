using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blogger.Domain
{
    public class Tag
    {
        public Tag()
        {
            List<Post> posts = new List<Post>();
        }

        public int id { get; set; }
        public string name { get; set; }
        [NotMapped]
        public virtual List<Post> posts { get; set; }
    }
}
