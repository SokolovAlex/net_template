using App.BLL.Abstract.Managers.Base;
using App.DAL.Abstract.Base;
using Autofac;

namespace App.BLL.Concrete.Managers.Base
{
    public class CategoryManager : ICategoryManager
    {
        public ICategoryRepository Repository { get; set; }

        public CategoryManager()
        {
            Repository = IoC.Instance.Resolve<ICategoryRepository>();
        }
    }
}