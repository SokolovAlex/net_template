using System.Linq;
using System.Web.Mvc;
using App.BLL;
using App.BLL.Abstract.Managers.Blog;
using Autofac;
using System.Web;
using App.BLL.Helpers;
using App.Web.Filters;

namespace App.Web.Areas.Blog.Controllers
{
    public class BlogHomeController : Controller
    {
        public ActionResult Index()
        {
            HttpCookie tokenCookie = HttpContext.Request.Cookies.Get("x-access-token");

            var sessionHelper = new SessionHelper();
            var user = sessionHelper.GetUser(tokenCookie.Value);
            FakeAuth.Auth2(user);

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