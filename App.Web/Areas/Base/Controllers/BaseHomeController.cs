using App.Web.Filters;
using System.Web.Mvc;

namespace App.Web.Areas.Base.Controllers
{
    public class BaseHomeController : Controller
    {
        public ActionResult Index()
        {
            var isAuth = FakeAuth.Auth(this.HttpContext);
            if (isAuth) {
                return View();
            }
            return View();
        }
    }
}