using System.Linq;
using App.DTO.Models.Base;

namespace App.DAL.Abstract.Base
{
    public interface ICategoryRepository
    {
        IQueryable<CategoryModel> GetBy();

        CategoryModel GetById(int id);
        IQueryable<CategoryModel> GetAll();
    }
}
