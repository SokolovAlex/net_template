using App.DAL.Abstract.News;

namespace App.BLL.Abstract.Managers.News
{
    public interface INewsManager
    {
        INewsRepository Repository { get; set; }
    }
}
