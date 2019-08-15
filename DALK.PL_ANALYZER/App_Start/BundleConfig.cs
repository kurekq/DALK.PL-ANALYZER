using System.Web;
using System.Web.Optimization;

namespace DALK.PL_ANALYZER
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/umd/popper.js",
                      "~/Scripts/bootstrap.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Scripts/umd/popper.js"
            ));


            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Content/js/app.min.js",
                        "~/Content/js/core.f6feac2f73a36da488af.js",
                        "~/Content/js/pagesshared.f6feac2f73a36da488af.js",
                        "~/Content/js/runtime.f6feac2f73a36da488af.js",
                        "~/Content/js/vendor.f6feac2f73a36da488af.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.*",
                      "~/Content/css/app.min.css",
                      "~/Content/css/icons.*",
                      "~/Content/site.css",
                      "~/Content/britejs.css",
                      "~/Content/core.css",
                      "~/Content/datatable.css",
                      "~/Content/editors.css",
                      "~/Content/vendor.css"
           ));
        }
    }
}
