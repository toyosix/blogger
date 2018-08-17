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
    }
}
