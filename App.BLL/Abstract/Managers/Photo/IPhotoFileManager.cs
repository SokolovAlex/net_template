using App.DAL.Abstract.Photo;

namespace App.BLL.Abstract.Managers.Photo
{
    public interface IPhotoFileManager
    {
        IPhotoFileRepository Repository { get; set; }
    }
}
