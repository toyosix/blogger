using Blogger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Services
{
    public interface ITagService
    {
        Task<bool> InsertTag(string name);
        Task<Tag> GetTagbyId(int id);
        List<Tag> GetTags();
    }
}
