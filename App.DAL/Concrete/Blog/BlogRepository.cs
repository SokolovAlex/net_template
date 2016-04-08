using System.Linq;
using App.DAL.Abstract.Blog;
using App.DAL.Concrete.Base;
using App.DAL.Entities.Blog;
using App.DTO.Models.Base;
using App.DTO.Models.Blog;

namespace App.DAL.Concrete.Blog
{
    public class BlogRepository : BaseRepository, IBlogRepository
    {
        public static BlogModel MapToModel(BlogEntity x)
        {
            var model = new BlogModel
            {
                Id = x.Id,
                UserId = x.UserId,
                IsActive = x.IsActive,
                Title = x.Title,
                Text = x.Text,
                Views = x.Views,
                Date = x.Date,
                IsPublished = x.IsPublished
            };

            return model;
        }

        public IQueryable<BlogModel> GetBy()
        {
            return Context.Blog.Select(x => new BlogModel
            {
                Id = x.Id,
                UserId = x.UserId,
                IsActive = x.IsActive,
                Title = x.Title,
                Text = x.Text,
                Views = x.Views,
                Date = x.Date,
                IsPublished = x.IsPublished,
                User = new UserModel
                {
                    Id = x.User.Id,
                    Nickname = x.User.Nickname
                }
            });
        }

        public BlogModel GetById(int id)
        {
            return GetBy().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<BlogModel> GetAll()
        {
            return GetBy().Where(x => x.IsActive).OrderByDescending(x => x.Date);
        }
    }
}
