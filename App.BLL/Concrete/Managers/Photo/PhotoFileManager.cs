using Autofac;
using App.BLL.Abstract.Managers.Photo;
using App.DAL.Abstract.Photo;

namespace App.BLL.Concrete.Managers.Photo
{
    public class PhotoFileManager : IPhotoFileManager
    {
        public IPhotoFileRepository Repository { get; set; }

        public PhotoFileManager()
        {
            Repository = IoC.Instance.Resolve<IPhotoFileRepository>();
        }
    }
}