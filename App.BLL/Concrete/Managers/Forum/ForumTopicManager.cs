using Autofac;
using App.BLL.Abstract.Managers.Forum;
using App.DAL.Abstract.Forum;

namespace App.BLL.Concrete.Managers.Forum
{
    public class ForumTopicManager : IForumTopicManager
    {
        public IForumTopicRepository Repository { get; set; }

        public ForumTopicManager()
        {
            Repository = IoC.Instance.Resolve<IForumTopicRepository>();
        }
    }
}