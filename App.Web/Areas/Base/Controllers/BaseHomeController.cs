using System.Web.Mvc;

namespace App.Web.Areas.Base.Controllers
{
    public class BaseHomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}