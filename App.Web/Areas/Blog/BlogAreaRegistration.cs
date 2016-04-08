using System.Web.Mvc;

namespace App.Web.Areas.Blog
{
    public class BlogAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Blog";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("Blog_Default", "Blog/{controller}/{action}/{id}", new { controller = "BlogHome", action = "Index", id = UrlParameter.Optional } );
        }
    }
}