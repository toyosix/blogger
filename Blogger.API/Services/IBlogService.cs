using Blogger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Services
{
    public interface IBlogService
    {
        Task<bool> InsertBlog(string name);
        Task<Blog> GetBlogbyId(int id);
        Task<Blog> GetBlogbyUser_id(int id);
    }
}
