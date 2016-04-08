using App.DAL.Abstract.Blog;

namespace App.BLL.Abstract.Managers.Blog
{
    public interface IBlogManager
    {
        IBlogRepository Repository { get; set; }
    }
}
