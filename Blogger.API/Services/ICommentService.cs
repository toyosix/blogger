using Blogger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Services
{
    public interface ICommentService
    {
        Task<bool> InsertComment(string fullname, string text, int post_id);
        Task<Comment> GetCommentbyId(int id);
        Task<Comment> GetCommentbyId_tracking(int id);
        Task<List<Comment>> GetCommentsbyPost_Id(int id);
    }
}
