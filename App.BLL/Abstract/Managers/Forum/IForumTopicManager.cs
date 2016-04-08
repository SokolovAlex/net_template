using App.DAL.Abstract.Forum;

namespace App.BLL.Abstract.Managers.Forum
{
    public interface IForumTopicManager
    {
        IForumTopicRepository Repository { get; set; }
    }
}
