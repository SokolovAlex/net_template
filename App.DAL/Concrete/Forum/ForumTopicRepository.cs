using System.Linq;
using App.DAL.Concrete.Base;
using App.DAL.Abstract.Forum;
using App.DAL.Entities.Forum;
using App.DTO.Models.Forum;

namespace App.DAL.Concrete.Forum
{
    public class ForumTopicRepository : BaseRepository, IForumTopicRepository
    {
        public static ForumTopicModel MapToModel(ForumTopicEntity x)
        {
            var model = new ForumTopicModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name
            };

            return model;
        }

        public IQueryable<ForumTopicModel> GetBy()
        {
            return Context.ForumTopic.Select(x => new ForumTopicModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Name = x.Name
            });
        }

        public ForumTopicModel GetById(int id)
        {
            return GetBy().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<ForumTopicModel> GetAll()
        {
            return GetBy().Where(x => x.IsActive).OrderBy(x => x.Name);
        }
    }
}
