using App.DAL.Abstract.Base;

namespace App.BLL.Abstract.Managers.Base
{
    public interface IUserManager
    {
        IUserRepository Repository { get; set; }
    }
}
