using System.Linq;
using App.DAL.Abstract.Base;
using App.DAL.Entities.Base;
using App.DTO.Models.Base;

namespace App.DAL.Concrete.Base
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public static CategoryModel MapToModel(CategoryEntity x)
        {
            var model = new CategoryModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name,
                Description = x.Description
            };

            return model;
        }

        public IQueryable<CategoryModel> GetBy()
        {
            return Context.Category.Select(x => new CategoryModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name,
                Description = x.Description
            });
        }

        public CategoryModel GetById(int id)
        {
            return GetBy().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<CategoryModel> GetAll()
        {
            return GetBy().Where(x => x.IsActive).OrderBy(x => x.Name);
        }
    }
}
