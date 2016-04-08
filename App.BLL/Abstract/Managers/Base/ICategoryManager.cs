using App.DAL.Abstract.Base;

namespace App.BLL.Abstract.Managers.Base
{
    public interface ICategoryManager
    {
        ICategoryRepository Repository { get; set; }
    }
}
