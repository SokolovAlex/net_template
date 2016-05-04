using App.Web.Areas.Auth.Services;
using System.Configuration;
using System.Web.Mvc;

namespace App.Web.Areas.Auth.Controllers
{
    public class AuthController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginModule()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult GoogleRedirect()
        {
            var conf = ConfigurationManager.AppSettings;
            var GoogleUrl = AuthResponse.GetAutenticationURI(conf["ClientIdGoogle"], conf["CallbackGoogle"]);
            return Redirect(GoogleUrl.AbsoluteUri);
        }

        public ActionResult LoginForm()
        {
            var conf = ConfigurationManager.AppSettings;

            return View(new AuthFormViewModel() {
                //GoogleUrl = AuthResponse.GetAutenticationURI(conf["clientIdGoogle"], conf["CallbackGoogle"]).AbsoluteUri
                GoogleUrl = Url.RouteUrl("Auth_Default", new { Controller = "Auth", Action = "GoogleRedirect" })
            });
        }

        public ActionResult GoogleCallback(string code)
        {
            var conf = ConfigurationManager.AppSettings;
            var GoogleUrl = AuthResponse.GetAutenticationURI(conf["ClientIdGoogle"], conf["CallbackGoogle"]);

            //Exchange the code for Access token and refreshtoken.
            AuthResponse access = AuthResponse.Exchange(code, conf["ClientIdGoogle"], conf["SecretGoogle"], conf["CallbackGoogle"]);

            if (access.Access_token == null) {
                return Redirect("ErrorPage");
            }

            return RedirectToAction("/");
        }
    }
}