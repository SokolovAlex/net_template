using System.Web.Mvc;

namespace App.Web.Areas.Base
{
    public class BaseAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Base";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("Base_Default", "Base/{controller}/{action}/{id}", new { controller= "BaseHome", action = "Index", id = UrlParameter.Optional });
        }
    }
}