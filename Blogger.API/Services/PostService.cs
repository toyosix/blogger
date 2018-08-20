using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.Data;
using Blogger.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public JToken GetAllPost()
        {
            var posts = dbcontext.Posts.Select(s => new { s.id, s.title, s.text, comment_count = s.comments.Count })
                .ToList(); // query projections

           var jsonObject = JObject.Parse(JsonConvert.SerializeObject(posts));

            return jsonObject;
        }

        public Task<Post> GetPostbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostByTag(int tag_id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertPost(string title, string text)
        {
            throw new NotImplementedException();
        }
    }
}
