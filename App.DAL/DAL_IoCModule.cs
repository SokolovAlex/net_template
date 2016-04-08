// ReSharper disable All

using Autofac;
using App.DAL.Abstract.Base;
using App.DAL.Abstract.Blog;
using App.DAL.Abstract.News;
using App.DAL.Concrete.Base;
using App.DAL.Concrete.Blog;
using App.DAL.Concrete.News;
using App.DAL.Abstract.Photo;
using App.DAL.Concrete.Photo;
using App.DAL.Abstract.Forum;
using App.DAL.Concrete.Forum;

namespace App.DAL
{
    public class DAL_IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region Base 
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<ReferenceRepository>().As<IReferenceRepository>();
            #endregion

            #region News
            builder.RegisterType<NewsRepository>().As<INewsRepository>();
            #endregion

            #region Blog
            builder.RegisterType<BlogRepository>().As<IBlogRepository>();
            #endregion

            #region Photo
            builder.RegisterType<PhotoFileRepository>().As<IPhotoFileRepository>();
            #endregion

            #region Forum
            builder.RegisterType<ForumTopicRepository>().As<IForumTopicRepository>();
            #endregion
        }
    }
}
