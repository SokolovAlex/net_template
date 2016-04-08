using App.BLL.Abstract.Managers.News;
using App.DAL.Abstract.News;
using Autofac;

namespace App.BLL.Concrete.Managers.News
{
    public class NewsManager : INewsManager
    {
        public INewsRepository Repository { get; set; }

        public NewsManager()
        {
            Repository = IoC.Instance.Resolve<INewsRepository>();
        }
    }
}