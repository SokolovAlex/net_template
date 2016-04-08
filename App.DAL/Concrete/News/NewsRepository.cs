using System.Linq;
using App.DAL.Abstract.News;
using App.DAL.Concrete.Base;
using App.DAL.Entities.News;
using App.DTO.Models.News;

namespace App.DAL.Concrete.News
{
    public class NewsRepository : BaseRepository, INewsRepository
    {
        public static NewsModel MapToModel(NewsEntity x)
        {
            var model = new NewsModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name,
                Text = x.Text,
                Date = x.Date, 
                Views = x.Views,
                IsPublished = x.IsPublished
            };

            return model;
        }

        public IQueryable<NewsModel> GetBy()
        {
            return Context.News.Select(x => new NewsModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name,
                Text = x.Text,
                Date = x.Date,
                Views = x.Views,
                IsPublished = x.IsPublished
            });
        }

        public NewsModel GetById(int id)
        {
            return GetBy().FirstOrDefault(x => x.Id == id);
        }

        public int Count()
        {
            return Context.News.Count();
        }

        public IQueryable<NewsModel> GetLast(int take)
        {
            return GetBy().OrderByDescending(x => x.Date).Take(take);
        }
    }
}
