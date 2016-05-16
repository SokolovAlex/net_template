using App.BLL.Helpers;
using App.DTO.Models.Base;
using App.Web.Areas.Auth.Services;
using App.Web.Filters;
using App.Web.Models;
using System.Configuration;
using System.Web;
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

        [App.Web.Filters.ExAuthorize]
        public ActionResult WelcomePage(string accessToken)
        {
            var sessionHelper = new SessionHelper();
            var user = sessionHelper.GetUser(accessToken);
            FakeAuth.Auth2(user);
            return View("WelcomePage", user.Session);
        }

        public ActionResult GoogleCallback(string code)
        {
            var helper = new UserHelper();
            var hashHelper = new HashHelper();
            var conf = ConfigurationManager.AppSettings;

            //Exchange the code for Access token and refreshtoken.
            AuthResponse access = AuthResponse.Exchange(code, conf["ClientIdGoogle"], conf["SecretGoogle"], conf["CallbackGoogle"]);

            if (access.Access_token == null) {
                return Redirect("ErrorPage");
            }

            var profile = access.GetProfileInfo2();

            var salt = hashHelper.GetSalt();

            var userModel = new UserModel
            {
                Email = profile.email,
                Name = profile.given_name,
                IsActive = true,
                Surname = profile.family_name,
                Nickname = profile.email,
                Avatar = profile.picture,
                Salt = salt,
                Password = hashHelper.GetSaltPassword("123456", salt)
            };

            helper.SaveUser(userModel);

            var sessionHelper = new SessionHelper();
            var sessionModel = sessionHelper.SessionCreate(userModel);

            

            //return View("WelcomePage", sessionModel);
            //return RedirectToAction("Index", "BaseHome", new { area = "Base"});
            return RedirectToAction("WelcomePage", new { accessToken = sessionModel.AssessToken});
        }
    }
}