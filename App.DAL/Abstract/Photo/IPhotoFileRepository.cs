using System.Linq;
using App.DTO.Models.Photo;

namespace App.DAL.Abstract.Photo
{
    public interface IPhotoFileRepository
    {
        IQueryable<PhotoFileModel> GetBy();

        PhotoFileModel GetById(int id);
        IQueryable<PhotoFileModel> GetAll();
    }
}
