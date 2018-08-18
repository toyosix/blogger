using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Domain
{
    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<PostTag> posttags { get; set; }
    }
}
