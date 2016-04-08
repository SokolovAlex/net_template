using System.Web.Mvc;

namespace App.Web.Areas.Feedback.Controllers
{
    public class FeedbackHomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}