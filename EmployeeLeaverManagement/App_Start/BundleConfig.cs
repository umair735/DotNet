using System.Web;
using System.Web.Optimization;

namespace EmployeeLeaverManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery-1.10.2.js",       
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"       
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/table").Include(
                        "~/Scripts/table.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/content/assets/font-awesome/css/font-awesome.css"));

            bundles.Add(new StyleBundle("~/AllContent/css").Include(
          "~/Content/assets/fullcalendar/fullcalendar/fullcalendar.css",
          "~/Content/assets/fullcalendar/fullcalendar/bootstrap-fullcalendar.css",
          "~/content/css/bootstrap.min.css",
          "~/content/css/bootstrap-reset.css",          
          "~/content/css/style.css",
          "~/content/css/style-responsive.css",
          "~/Content/css/table-style.css",
          "~/Content/css/basictable.css"));


            bundles.Add(new ScriptBundle("~/bundles/AllScript").Include(
          "~/Content/js/jquery.basictable.min.js",
          "~/content/js/bootstrap.min.js",
          "~/content/js/jquery.dcjqaccordion.2.7.js",
          "~/content/js/jquery.scrollTo.min.js",
          "~/content/js/jquery.nicescroll.js",
          "~/content/js/respond.min.js",
          "~/Content/assets/fullcalendar/fullcalendar/fullcalendar.min.js",
          "~/Content/js/external-dragging-calendar.js",
          "~/content/js/common-scripts.js",
          "~/Scripts/jquery.validate.min.js",
          "~/Scripts/jquery.validate.unobtrusive.min.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
