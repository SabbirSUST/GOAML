using System.Web;
using System.Web.Optimization;

namespace GOAML.Display
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", 
                        "~/Scripts/jquery-ui-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/alertify.js",
                      "~/Scripts/alertify.min.js"
                      ,"~/Scripts/underscore.string.min.js"
                      ,"~/Scripts/underscore-min.js"
                      ,"~/Scripts/menu.js"
                      ,"~/Scripts/customs/business-information.js"
                      ,"~/Scripts/customs/cust.info.upload.js"
                      ,"~/Scripts/customs/customer-information.js"
                      ,"~/Scripts/customs/director-information.js"
                      , "~/Scripts/customs/individual-information.js"
                      ,"~/Scripts/customs/goaml-generics.js"
                      , "~/Scripts/customs/np-controller.js"
                      ,"~/Scripts/customs/sabbir.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"
                      , "~/Content/jquery-ui.css"
                      ,"~/Content/Site.css"
                      , "~/Content/datepicker.css"
                      , "~/Content/datepicker.less"
                      , "~/Content/CustomStyle.css"
                      , "~/Content/new.css"
                      , "~/Content/alertify.min.css"
                      , "~/Content/default.min.css"
                      , "~/font-awesome-4.5.0/css/font-awesome.min.css"
                      ));
        }
    }
}
