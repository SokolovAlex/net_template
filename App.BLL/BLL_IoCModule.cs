// ReSharper disable All

using App.BLL.Abstract.Helpers;
using Autofac;
using App.BLL.Abstract.Managers.Base;
using App.BLL.Abstract.Managers.Blog;
using App.BLL.Abstract.Managers.News;
using App.BLL.Concrete.Managers.Base;
using App.BLL.Concrete.Managers.Blog;
using App.BLL.Concrete.Managers.News;
using App.BLL.Abstract.Managers.Photo;
using App.BLL.Concrete.Managers.Photo;
using App.BLL.Abstract.Managers.Forum;
using App.BLL.Concrete.Helpers;
using App.BLL.Concrete.Managers.Forum;

namespace App.BLL
{
    public class BLL_IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region Base
            builder.RegisterType<RedisCacheHelper>().As<IRedisCacheHelper>();
            builder.RegisterType<UserManager>().As<IUserManager>();
            builder.RegisterType<CategoryManager>().As<ICategoryManager>();
            builder.RegisterType<ReferenceManager>().As<IReferenceManager>();
            #endregion

            #region News
            builder.RegisterType<NewsManager>().As<INewsManager>();
            #endregion

            #region Blog
            builder.RegisterType<BlogManager>().As<IBlogManager>();
            #endregion

            #region Photo
            builder.RegisterType<PhotoFileManager>().As<IPhotoFileManager>();
            #endregion

            #region Forum
            builder.RegisterType<ForumTopicManager>().As<IForumTopicManager>();
            #endregion
        }
    }
}
