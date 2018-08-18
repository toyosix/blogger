using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.Data;
using Blogger.Domain;

namespace Blogger.API.Services
{
    public class CommentService : ICommentService
    {
        BloggerContext dbcontext = null;
        Comment comment = null;

        public CommentService(BloggerContext dbcontext)
        {
            this.dbcontext = dbcontext;
            comment = new Comment();
        }

        public Task<List<Comment>> GetCommentbyPost_Id(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetUserbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetUserbyId_tracking(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertComment(string fullname, string text, int post_id)
        {
            throw new NotImplementedException();
        }
    }
}
