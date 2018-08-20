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
        Task<bool> InsertPost(string title, string text);
        Task<Post> GetPostbyId(int id);
        JToken GetAllPost();
        Task<Post> GetPostByTag(int tag_id);
    }
}
