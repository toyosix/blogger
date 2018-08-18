using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.Data;
using Blogger.Domain;

namespace Blogger.API.Services
{
    public class TagService : ITagService
    {
        BloggerContext dbcontext = null;
        Tag tag = null;

        public TagService(BloggerContext dbcontext)
        {
            this.dbcontext = dbcontext;
            tag = new Tag();
        }
        
        public Task<Tag> GetTagbyId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetTags()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertTag(string name)
        {
            throw new NotImplementedException();
        }
    }
}
