using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using App.DAL.Entities.Base;
using App.DAL.Entities.Blog;
using App.DAL.Entities.News;
using App.DAL.Entities.Photo;
using App.DAL.Entities.Forum;

namespace App.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext")
        {
        }

        #region Base
        public DbSet<UserEntity> User { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<ReferenceEntity> Reference { get; set; }
        #endregion

        #region News
        public DbSet<NewsEntity> News { get; set; }
        #endregion

        #region Blog 
        public DbSet<BlogEntity> Blog { get; set; }
        #endregion

        #region Photo
        public DbSet<PhotoFileEntity> PhotoFile { get; set; }
        #endregion

        #region Forum
        public DbSet<ForumTopicEntity> ForumTopic { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}