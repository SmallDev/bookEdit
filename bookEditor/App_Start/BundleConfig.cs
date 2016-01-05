using System.Web;
using System.Web.Optimization;

namespace bookEditor
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsApp").Include(
                      "~/Scripts/angular/angular.js",
                      "~/Scripts/app/app.js",
                      "~/Scripts/app/modules/angular-route.js",
                      "~/Scripts/app/modules/ng-file-upload-shim.js",
                      "~/Scripts/app/modules/ng-file-upload.js",
                      "~/Scripts/app/controllers/addBookCtrl.js",
                      "~/Scripts/app/controllers/authorListCtrl.js",
                      "~/Scripts/app/controllers/bookListCtrl.js",
                      "~/Scripts/app/controllers/editBookCtrl.js",
                      "~/Scripts/app/controllers/mainCtrl.js",
                      "~/Scripts/app/services/bookService.js",
                      "~/Scripts/app/services/authorService.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.css.map",
                      "~/Content/site.css"));   
        }
    }
}
