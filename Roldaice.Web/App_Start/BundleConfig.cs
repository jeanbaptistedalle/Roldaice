using System.Web;
using System.Web.Optimization;

namespace Roldaice.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts
            bundles.Add(new ScriptBundle("~/Bundles/Mordernizr")
                .Include("~/Scripts/Dependency/mordernizr-2.8.3.js")
            );

            bundles.Add(new ScriptBundle("~/Bundles/Dependency")
                .Include("~/Scripts/Dependency/bootstrap.min.js")
                .Include("~/Scripts/Dependency/moment-with-locales.min.js")
                .Include("~/Scripts/Dependency/jquery-3.3.1.min.js")
                .Include("~/Scripts/Dependency/jquery.validate.min.js")
                .Include("~/Scripts/Dependency/jquery.validate.unobstrusive.min.js")
                .Include("~/Scripts/Dependency/bootstrap-confirmation.min.js")
                .Include("~/Scripts/Dependency/bootstrap-datetimepicker.min.js")
                .Include("~/Scripts/Dependency/bootstrap-select.min.js")
                .Include("~/Scripts/Dependency/bootstrap-slider.min.js")
                .Include("~/Scripts/Dependency/bootstrap-toggle.min.js")
                .Include("~/Scripts/Dependency/datatables.min.js")
                .Include("~/Scripts/Dependency/toastr.min.js")
                .Include("~/Scripts/Dependency/pnglib.min.js")
                .Include("~/Scripts/Dependency/identicon.min.js")
            );

            bundles.Add(new ScriptBundle("~/Bundles/Site")
                .Include("~/Scripts/Site.js")
            );
            #endregion Scripts

            #region Styles
            bundles.Add(new StyleBundle("~/Bundles/Dependency/Css")
                .Include("~/Content/Dependency/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Dependency/bootstrap-theme.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Dependency/bootstrap-datetimepicker.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Dependency/bootstrap-select.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Dependency/bootstrap-slider.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Dependency/bootstrap-toggle.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Dependency/datatables.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Dependency/font-awesome.min.css", new CssRewriteUrlTransform())
            );
            
            bundles.Add(new StyleBundle("~/Bundles/Site/Css")
                .Include("~/Content/Site.css", new CssRewriteUrlTransform())
                .Include("~/Content/bootstrap-extension.css", new CssRewriteUrlTransform())
                .Include("~/Content/Components/loader.css", new CssRewriteUrlTransform())
                .Include("~/Content/Components/image-overlay.css", new CssRewriteUrlTransform())
            );
            #endregion Scripts
        }
    }
}
