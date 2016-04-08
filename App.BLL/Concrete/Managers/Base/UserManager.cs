using App.BLL.Abstract.Managers.Base;
using App.DAL.Abstract.Base;
using Autofac;

namespace App.BLL.Concrete.Managers.Base
{
    public class UserManager : IUserManager
    {
        public IUserRepository Repository { get; set; }

        public UserManager()
        {
            Repository = IoC.Instance.Resolve<IUserRepository>();
        }
    }
}
