using System.Web.Mvc;

namespace App.Web.Areas.Auth.Controllers
{
    public class AuthHomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
    }
}