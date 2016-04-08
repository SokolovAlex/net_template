using App.DAL.Abstract.Base;

namespace App.BLL.Abstract.Managers.Base
{
    public interface IReferenceManager
    {
        IReferenceRepository Repository { get; set; }
    }
}
