using System.Web.Mvc;

namespace App.Web.Areas.Test
{
    public class TestAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Test";
     
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Test_default",
                "Test/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}