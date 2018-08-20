using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.Data;
using Blogger.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Blogger.API.Services
{
    public class PostService : IPostService
    {
        BloggerContext dbcontext = null;
        Post post = null;
        Tag tag = null;

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

        public Post InsertPost(int blog_id, string title, string text, string[] tags)
        {
            try
            {
                post = new Post { blog_id = blog_id, title = title, text = text };
                dbcontext.Add(post); // track posts
                dbcontext.SaveChanges();

                foreach (var item in tags)
                {
                    tag = new Tag { name = item };
                    dbcontext.Entry(tag).State = dbcontext.Tags.Any(t => t.name == item)
                        ? EntityState.Unchanged
                        : EntityState.Added;

                    dbcontext.SaveChanges();

                    var ptJoin = new PostTag { post_id = post.id, tag_id = tag.id };
                    dbcontext.Add(ptJoin);
                    dbcontext.SaveChanges();
                }
                return post;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
