using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.CustomTypes
{
    public class _PostTag
    {
        public int id { get; set; }
        public int blog_id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string[] tags { get; set; }
    }
}
