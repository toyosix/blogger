using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.API.Lib;
using Blogger.Data;
using Blogger.Domain;

namespace Blogger.API.Service
{
    public interface IUserService
    {
        Task<bool> InsertUser(string name);
        Task<User> GetUserbyId(int id);
        Task<User> GetUserbyId_tracking(int id);
        Task<List<User>> GetAllUser();
        Task<bool> UserExists(int id);
        Task<bool> UpdateUser(int id, User user);
        Task<bool> DeleteUser(int id);
    }
}
