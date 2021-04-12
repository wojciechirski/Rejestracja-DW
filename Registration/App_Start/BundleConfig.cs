using System.Web;
using System.Web.Optimization;

namespace Registration
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/jquery/dist/jquery.min.js",
                      "~/Content/flip/flip.min.js",
                      "~/Content/flipTimer/jquery.flipTimer.js",
                      "~/Content/flipclock/flipclock.js",
                      "~/Content/bootstrap/dist/js/bootstrap.min.js",
                      "~/Content/smooth-scroll/dist/js/smooth-scroll.min.js",
                      "~/Content/js/main.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/dist/css/bootstrap.min.css",
                      "~/Content/main.css",
                      "~/Content/flipclock/flipclock.css",
                      "~/Content/style.css"));
            
                                  

        }
    }
}
