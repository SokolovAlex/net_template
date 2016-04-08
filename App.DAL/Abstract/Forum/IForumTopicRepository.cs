using System.Linq;
using App.DTO.Models.Forum;

namespace App.DAL.Abstract.Forum
{
    public interface IForumTopicRepository
    {
        IQueryable<ForumTopicModel> GetBy();

        ForumTopicModel GetById(int id);
        IQueryable<ForumTopicModel> GetAll();
    }
}
