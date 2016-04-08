using System.Linq;
using System.Web.Mvc;
using App.BLL;
using App.BLL.Abstract.Managers.Blog;
using Autofac;

namespace App.Web.Areas.Blog.Controllers
{
    public class BlogHomeController : Controller
    {
        public ActionResult Index()
        {
            var blogPostManager = IoC.Instance.Resolve<IBlogManager>();

            var posts = blogPostManager.Repository.GetAll().ToList();

            return View(posts);
        }

        public ActionResult Details(int id)
        {
            var blogPostManager = IoC.Instance.Resolve<IBlogManager>();

            var news = blogPostManager.Repository.GetById(id);

            return View(news);
        }
    }
}