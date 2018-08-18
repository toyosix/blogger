using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.Data;
using Blogger.Domain;

namespace Blogger.API.Services
{
    public class PostService : IPostService
    {
        BloggerContext dbcontext = null;
        Post post = null;

        public PostService(BloggerContext dbcontext)
        {
            this.dbcontext = dbcontext;
            post = new Post();
        }

        public Task<List<Post>> GetAllPost()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostbyId_tracking(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertPost(string title, string text)
        {
            throw new NotImplementedException();
        }
    }
}
