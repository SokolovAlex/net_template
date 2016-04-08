using App.BLL.Abstract.Managers.Blog;
using App.DAL.Abstract.Blog;
using Autofac;

namespace App.BLL.Concrete.Managers.Blog
{
    public class BlogManager : IBlogManager
    {
        public IBlogRepository Repository { get; set; }

        public BlogManager()
        {
            Repository = IoC.Instance.Resolve<IBlogRepository>();
        }
    }
}