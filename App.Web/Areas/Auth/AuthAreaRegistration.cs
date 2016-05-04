using System.Web.Mvc;

namespace App.Web.Areas.Auth
{
    public class AuthAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Auth";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("Auth_Default", "Auth/{controller}/{action}/{id}", new { controller= "Auth", action = "Index", id = UrlParameter.Optional });
        }
    }
}