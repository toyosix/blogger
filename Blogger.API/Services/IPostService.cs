using Blogger.Domain;
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
        Task<Post> GetPostbyId_tracking(int id);
        Task<List<Post>> GetAllPost();
    }
}
