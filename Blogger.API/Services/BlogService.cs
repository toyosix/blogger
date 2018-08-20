using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.Data;
using Blogger.Domain;

namespace Blogger.API.Services
{
    public class BlogService : IBlogService
    {
        BloggerContext dbcontext = null;
        Blog blog = null;

        public BlogService(BloggerContext dbcontext)
        {
            this.dbcontext = dbcontext;
            blog = new Blog();
        }

        public Task<Blog> GetBlogbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> GetBlogbyUser_id(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertBlog(string name)
        {
            throw new NotImplementedException();
        }
    }
}
