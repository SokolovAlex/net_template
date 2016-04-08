using System.Linq;
using App.DAL.Concrete.Base;
using App.DAL.Abstract.Photo;
using App.DAL.Entities.Photo;
using App.DTO.Models.Photo;

namespace App.DAL.Concrete.Photo
{
    public class PhotoFileRepository : BaseRepository, IPhotoFileRepository
    {
        public static PhotoFileModel MapToModel(PhotoFileEntity x)
        {
            var model = new PhotoFileModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name
            };

            return model;
        }

        public IQueryable<PhotoFileModel> GetBy()
        {
            return Context.PhotoFile.Select(x => new PhotoFileModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name
            });
        }

        public PhotoFileModel GetById(int id)
        {
            return GetBy().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<PhotoFileModel> GetAll()
        {
            return GetBy().Where(x => x.IsActive).OrderBy(x => x.Name);
        }
    }
}
