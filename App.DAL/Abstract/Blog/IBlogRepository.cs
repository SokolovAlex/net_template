using System.Linq;
using App.DTO.Models.Blog;

namespace App.DAL.Abstract.Blog
{
    public interface IBlogRepository
    {
        IQueryable<BlogModel> GetBy();

        BlogModel GetById(int id);
        IQueryable<BlogModel> GetAll();
    }
}
