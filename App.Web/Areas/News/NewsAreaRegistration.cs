using System.Web.Mvc;

namespace App.Web.Areas.News
{
    public class NewsAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "News";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("News_Default", "News/{controller}/{action}/{id}", new { controller = "NewsHome", action = "Index", id = UrlParameter.Optional });
        }
    }
}