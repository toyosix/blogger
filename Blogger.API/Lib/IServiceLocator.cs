using Blogger.Data;

namespace Blogger.API.Lib
{
    public interface IServiceLocator
    {
        T GetService<T>(BloggerContext dbcontext);
        void Register<I, C>();             
    }
}