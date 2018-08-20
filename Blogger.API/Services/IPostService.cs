using Blogger.Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Services
{
    public interface IPostService
    {
        Post InsertPost(int blog_id, string title, string text, string[] tag);
        Task<Post> GetPostbyId(int id);
        JToken GetAllPost();
        Task<Post> GetPostByTag(int tag_id);
    }
}
