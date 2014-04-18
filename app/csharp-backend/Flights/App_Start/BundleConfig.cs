using System.Web;
using System.Web.Optimization;

namespace Flights
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .IncludeDirectory("~/Content/Style/", "*.css"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .IncludeDirectory("~/Scripts/app", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib")
                .Include("~/Scripts/lib/angular.js")
                .Include("~/Scripts/lib/angular-route.js"));
        }
    }
}