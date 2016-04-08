using System.Linq;
using App.DTO.Models.News;

namespace App.DAL.Abstract.News
{
    public interface INewsRepository
    {
        IQueryable<NewsModel> GetBy();

        NewsModel GetById(int id);
        IQueryable<NewsModel> GetLast(int count);
        int Count();
    }
}
