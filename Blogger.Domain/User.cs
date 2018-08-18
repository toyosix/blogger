using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Domain
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public Blog blog { get; set; }
    }
}
