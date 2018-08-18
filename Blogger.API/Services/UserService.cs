using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.API.Lib;
using Blogger.Data;
using Blogger.Domain;
using Microsoft.EntityFrameworkCore;

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

           

            var isSaved = await dbcontext.SaveChangesAsync(); // insert into DB

            //dbcontext.Entry(user).State = EntityState.Detached; // remove user entity from tracking/memory

            return isSaved >= 1 ? true : false;
        }

        public async Task<User> GetUserbyId(int id)
        {
            var user = await this.dbcontext.Users.AsNoTracking().OrderBy(o=>o.id).FirstOrDefaultAsync(u => u.id == id); // untracked : from DB

            return user;
        }

        public async Task<User> GetUserbyId_tracking(int id)
        {
            var user = await this.dbcontext.Users.FindAsync(id); // find in memory

            return user;
        }

        public async Task<List<User>> GetAllUser()
        {
            var users = await this.dbcontext.Users.ToListAsync();
            return users;
        }

        public async Task<bool> UserExists(int id)
        {
            return await this.dbcontext.Users.AnyAsync(e => e.id == id);
        }

        public async Task<bool> UpdateUser(int id, User user)
        {
            this.dbcontext.Entry(user).State = EntityState.Modified;

            try
            {
               var saved = await this.dbcontext.SaveChangesAsync();

                return saved >= 1 ? true : false;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await this.dbcontext.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            this.dbcontext.Users.Remove(user);
           var saved = await this.dbcontext.SaveChangesAsync();

            return saved >= 1 ? true : false;
        }
       
    }
}
