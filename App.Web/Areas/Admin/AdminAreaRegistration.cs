using System.Web.Mvc;

namespace App.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("Admin_Default", "Admin/{controller}/{action}/{id}", new { controller= "AdminHome", action = "Index", id = UrlParameter.Optional });
        }
    }
}