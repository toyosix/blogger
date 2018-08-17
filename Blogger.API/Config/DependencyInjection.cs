using Blogger.API.Lib;
using Blogger.API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.API.Config
{
    public class DependencyInjection
    {

        public DependencyInjection()
        {
            AddServices();
        }

        public void AddServices()
        {
            //REGISTER USER SERVICE
            ServiceLocator.Instance.Register<IUserService, UserService>();
        }

    }
}
