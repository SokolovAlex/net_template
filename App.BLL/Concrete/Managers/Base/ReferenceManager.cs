using App.BLL.Abstract.Managers.Base;
using App.DAL.Abstract.Base;
using Autofac;

namespace App.BLL.Concrete.Managers.Base
{
    public class ReferenceManager : IReferenceManager
    {
        public IReferenceRepository Repository { get; set; }

        public ReferenceManager()
        {
            Repository = IoC.Instance.Resolve<IReferenceRepository>();
        }
    }
}