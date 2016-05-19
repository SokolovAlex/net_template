using App.BLL.Helpers;
using App.Web.Filters;
using System.Web.Mvc;

namespace App.Web.Areas.Base.Controllers
{
    public class BaseHomeController : Controller
    {
        public ActionResult Index()
        {
            var accessToken = HttpContext.Request.Cookies["x-access-token"].Value;
            var sessionHelper = new SessionHelper();
            var user = sessionHelper.GetUser(accessToken);
            FakeAuth.Auth2(user);
            return View();
        }

        public ActionResult Users()
        {
            var accessToken = HttpContext.Request.Cookies["x-access-token"].Value;
            var sessionHelper = new SessionHelper();
            var user = sessionHelper.GetUser(accessToken);
            FakeAuth.Auth2(user);
            return View();
        }

    }
}