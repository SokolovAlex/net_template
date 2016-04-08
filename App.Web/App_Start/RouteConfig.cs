using System.Web.Mvc;
using System.Web.Routing;

namespace App.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RegisterNews(routes);

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "BaseHome", action = "Index", id = UrlParameter.Optional }).DataTokens.Add("area", "Base");
        }

        private static void RegisterNews(RouteCollection routes)
        {
            routes.MapRoute("News_Index", "novosti", new { controller = "NewsHome", action = "Index" });
        }
    }
}
