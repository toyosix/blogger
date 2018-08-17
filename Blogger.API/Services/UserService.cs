using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.API.Lib;
using Blogger.Data;
using Blogger.Domain;

namespace Blogger.API.Service
{
    public class UserService : IUserService
    {
        BloggerContext dbcontext = null;
        User user = null;

        public UserService(BloggerContext dbcontext)
        {
            this.dbcontext = dbcontext;
            user = new User();
        }

        public async Task<bool> InsertUser(string name)
        {
            user.name = name;
            dbcontext.Add(user); // tracking user object

            var timestamp = DateTime.Now;

            dbcontext.Entry(user).Property("created_at").CurrentValue = timestamp; // adding shadow properties
            dbcontext.Entry(user).Property("updated_at").CurrentValue = timestamp; // adding shadow properties

            var isSaved = await dbcontext.SaveChangesAsync(); // insert into DB

            return isSaved >= 1 ? true : false;
        }

        public async Task<User> GetUserbyId(int id)
        {
            var user = await this.dbcontext.Users.FindAsync(id); // find in memory

            return user;
        }




    }
}
