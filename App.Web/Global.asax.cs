using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using App.BLL;
using App.BLL.Abstract.Managers.Base;
using App.BLL.Concrete.Helpers;
using App.DTO.Enums;
using Autofac;
using Newtonsoft.Json.Serialization;

namespace App.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IoCConfig.Initialize();

            SettingsHelper.Instance.Init(IoC.Instance.Resolve<IReferenceManager>().Repository.GetByCategoryId((int)BaseEnums.Reference.Category.Settings));

            var config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}
