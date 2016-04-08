using System.Web.Optimization;

namespace App.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS
            bundles.Add(new StyleBundle("~/css")
                .Include("~/Content/normalize.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/style.css")
            );

            // JS
            bundles.Add(new ScriptBundle("~/js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")
                .Include("~/Scripts/bootstrap.js")
            );

            bundles.Add(new ScriptBundle("~/app")
                .Include("~/Scripts/app/App.js")
            );

            BundleTable.EnableOptimizations = true;

            #if DEBUG
            BundleTable.EnableOptimizations = false;
            #endif
        }
    }
}
