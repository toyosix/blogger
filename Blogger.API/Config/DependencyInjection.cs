using Blogger.API.Lib;
using Blogger.API.Service;
using Blogger.API.Services;
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

            //REGISTER BLOG SERVICE
            ServiceLocator.Instance.Register<IBlogService, BlogService>();

            //REGISTER COMMENT SERVICE
            ServiceLocator.Instance.Register<ICommentService, CommentService>();

            //REGISTER POST SERVICE
            ServiceLocator.Instance.Register<IPostService, PostService>();

            //REGISTER TAG SERVICE
            ServiceLocator.Instance.Register<ITagService, TagService>();
        }

    }
}
