using App.BLL.Helpers;
using App.DAL.Concrete.Base;
using App.Web.Filters;
using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;

namespace App.Web.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        public ActionResult Index()
        {
            HttpCookie tokenCookie = HttpContext.Request.Cookies.Get("x-access-token");
            var sessionHelper = new SessionHelper();
            var user = sessionHelper.GetUser(tokenCookie.Value);
            FakeAuth.Auth2(user);

            return View();
        }

        public string UsersList()
        {
            HttpCookie tokenCookie = HttpContext.Request.Cookies.Get("x-access-token");
            var sessionHelper = new SessionHelper();
            var user = sessionHelper.GetUser(tokenCookie.Value);
            FakeAuth.Auth2(user);

            var rep = new UserRepository();

            var result = rep.GetAll();

            return JsonConvert.SerializeObject(result);
        }
    }
}