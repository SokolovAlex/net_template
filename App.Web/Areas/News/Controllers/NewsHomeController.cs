using System.Web.Mvc;
using App.BLL;
using App.BLL.Abstract.Managers.News;
using App.DTO.ViewModels.News;
using Autofac;

namespace App.Web.Areas.News.Controllers
{
    public class NewsHomeController : Controller
    {
        public ActionResult Index()
        {
            var newsManager = IoC.Instance.Resolve<INewsManager>();

            var model = new NewsHomeViewModel
            {
                Total = newsManager.Repository.Count(),
                News = newsManager.Repository.GetLast(10)
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var newsManager = IoC.Instance.Resolve<INewsManager>();

            var news = newsManager.Repository.GetById(id);

            return View(news);
        }
    }
}