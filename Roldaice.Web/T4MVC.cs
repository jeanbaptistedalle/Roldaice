﻿// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
public static partial class MVC
{
    public static Roldaice.Web.Controllers.AuthenticationController Authentication = new Roldaice.Web.Controllers.T4MVC_AuthenticationController();
    public static Roldaice.Web.Controllers.CryptographController Cryptograph = new Roldaice.Web.Controllers.T4MVC_CryptographController();
    public static Roldaice.Web.Controllers.ErrorController Error = new Roldaice.Web.Controllers.T4MVC_ErrorController();
    public static Roldaice.Web.Controllers.HomeController Home = new Roldaice.Web.Controllers.T4MVC_HomeController();
    public static Roldaice.Web.Controllers.RollDiceController RollDice = new Roldaice.Web.Controllers.T4MVC_RollDiceController();
    public static Roldaice.Web.Controllers.TestController Test = new Roldaice.Web.Controllers.T4MVC_TestController();
    public static T4MVC.SharedController Shared = new T4MVC.SharedController();
}

namespace T4MVC
{
}

#pragma warning disable 0436
namespace T4MVC
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class Dummy
    {
        private Dummy() { }
        public static Dummy Instance = new Dummy();
    }
}
#pragma warning restore 0436

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ActionResult : System.Web.Mvc.ActionResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ActionResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
     
    public override void ExecuteResult(System.Web.Mvc.ControllerContext context) { }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}
[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal partial class T4MVC_System_Web_Mvc_ViewResult : System.Web.Mvc.ViewResult, IT4MVCActionResult
{
    public T4MVC_System_Web_Mvc_ViewResult(string area, string controller, string action, string protocol = null): base()
    {
        this.InitMVCT4Result(area, controller, action, protocol);
    }
    
    public string Controller { get; set; }
    public string Action { get; set; }
    public string Protocol { get; set; }
    public RouteValueDictionary RouteValueDictionary { get; set; }
}



namespace Links
{
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Scripts {
        public const string UrlPath = "~/Scripts";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Dependency {
            public const string UrlPath = "~/Scripts/Dependency";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string bootstrap_confirmation_min_js = Url("bootstrap-confirmation.min.js");
            public static readonly string bootstrap_datetimepicker_min_js = Url("bootstrap-datetimepicker.min.js");
            public static readonly string bootstrap_select_min_js = Url("bootstrap-select.min.js");
            public static readonly string bootstrap_slider_min_js = Url("bootstrap-slider.min.js");
            public static readonly string bootstrap_toggle_min_js = Url("bootstrap-toggle.min.js");
            public static readonly string bootstrap_min_js = Url("bootstrap.min.js");
            public static readonly string datatables_min_js = Url("datatables.min.js");
            public static readonly string jquery_3_3_1_min_js = Url("jquery-3.3.1.min.js");
            public static readonly string jquery_validate_min_js = Url("jquery.validate.min.js");
            public static readonly string jquery_validate_unobtrusive_min_js = Url("jquery.validate.unobtrusive.min.js");
            public static readonly string modernizr_2_8_3_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/modernizr-2.8.3.min.js") ? Url("modernizr-2.8.3.min.js") : Url("modernizr-2.8.3.js");
            public static readonly string moment_with_locales_min_js = Url("moment-with-locales.min.js");
            public static readonly string toastr_min_js = Url("toastr.min.js");
        }
    
        public static readonly string Site_js = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Site.min.js") ? Url("Site.min.js") : Url("Site.js");
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static class Content {
        public const string UrlPath = "~/Content";
        public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
        public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
        public static readonly string bootstrap_extension_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/bootstrap-extension.min.css") ? Url("bootstrap-extension.min.css") : Url("bootstrap-extension.css");
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Components {
            public const string UrlPath = "~/Content/Components";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string loader_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/loader.min.css") ? Url("loader.min.css") : Url("loader.css");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Dependency {
            public const string UrlPath = "~/Content/Dependency";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string bootstrap_datetimepicker_min_css = Url("bootstrap-datetimepicker.min.css");
            public static readonly string bootstrap_select_min_css = Url("bootstrap-select.min.css");
            public static readonly string bootstrap_slider_min_css = Url("bootstrap-slider.min.css");
            public static readonly string bootstrap_theme_min_css = Url("bootstrap-theme.min.css");
            public static readonly string bootstrap_toggle_min_css = Url("bootstrap-toggle.min.css");
            public static readonly string bootstrap_min_css = Url("bootstrap.min.css");
            public static readonly string datatables_min_css = Url("datatables.min.css");
            public static readonly string font_awesome_min_css = Url("font-awesome.min.css");
        }
    
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public static class Fonts {
            public const string UrlPath = "~/Content/Fonts";
            public static string Url() { return T4MVCHelpers.ProcessVirtualPath(UrlPath); }
            public static string Url(string fileName) { return T4MVCHelpers.ProcessVirtualPath(UrlPath + "/" + fileName); }
            public static readonly string fontawesome_webfont_ttf = Url("fontawesome-webfont.ttf");
            public static readonly string fontawesome_webfont_woff = Url("fontawesome-webfont.woff");
            public static readonly string fontawesome_webfont_woff2 = Url("fontawesome-webfont.woff2");
            public static readonly string FontAwesome_otf = Url("FontAwesome.otf");
        }
    
        public static readonly string Site_css = T4MVCHelpers.IsProduction() && T4Extensions.FileExists(UrlPath + "/Site.min.css") ? Url("Site.min.css") : Url("Site.css");
    }

    
    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public static partial class Bundles
    {
        public static partial class Scripts 
        {
            public static partial class Dependency 
            {
                public static class Assets
                {
                    public static readonly string bootstrap_confirmation_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/bootstrap-confirmation.min.js"); 
                    public static readonly string bootstrap_datetimepicker_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/bootstrap-datetimepicker.min.js"); 
                    public static readonly string bootstrap_select_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/bootstrap-select.min.js"); 
                    public static readonly string bootstrap_slider_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/bootstrap-slider.min.js"); 
                    public static readonly string bootstrap_toggle_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/bootstrap-toggle.min.js"); 
                    public static readonly string bootstrap_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/bootstrap.min.js"); 
                    public static readonly string datatables_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/datatables.min.js"); 
                    public static readonly string jquery_3_3_1_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/jquery-3.3.1.min.js"); 
                    public static readonly string jquery_validate_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/jquery.validate.min.js"); 
                    public static readonly string jquery_validate_unobtrusive_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/jquery.validate.unobtrusive.min.js"); 
                    public static readonly string modernizr_2_8_3_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/modernizr-2.8.3.js"); 
                    public static readonly string moment_with_locales_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/moment-with-locales.min.js"); 
                    public static readonly string toastr_min_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Dependency/toastr.min.js"); 
                }
            }
            public static class Assets
            {
                public static readonly string Site_js = T4MVCHelpers.ProcessAssetPath("~/Scripts/Site.js"); 
            }
        }
        public static partial class Content 
        {
            public static partial class Components 
            {
                public static class Assets
                {
                    public static readonly string loader_css = T4MVCHelpers.ProcessAssetPath("~/Content/Components/loader.css");
                }
            }
            public static partial class Dependency 
            {
                public static class Assets
                {
                    public static readonly string bootstrap_datetimepicker_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/Dependency/bootstrap-datetimepicker.min.css");
                    public static readonly string bootstrap_select_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/Dependency/bootstrap-select.min.css");
                    public static readonly string bootstrap_slider_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/Dependency/bootstrap-slider.min.css");
                    public static readonly string bootstrap_theme_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/Dependency/bootstrap-theme.min.css");
                    public static readonly string bootstrap_toggle_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/Dependency/bootstrap-toggle.min.css");
                    public static readonly string bootstrap_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/Dependency/bootstrap.min.css");
                    public static readonly string datatables_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/Dependency/datatables.min.css");
                    public static readonly string font_awesome_min_css = T4MVCHelpers.ProcessAssetPath("~/Content/Dependency/font-awesome.min.css");
                }
            }
            public static partial class Fonts 
            {
                public static class Assets
                {
                }
            }
            public static class Assets
            {
                public static readonly string bootstrap_extension_css = T4MVCHelpers.ProcessAssetPath("~/Content/bootstrap-extension.css");
                public static readonly string Site_css = T4MVCHelpers.ProcessAssetPath("~/Content/Site.css");
            }
        }
    }
}

[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
internal static class T4MVCHelpers {
    // You can change the ProcessVirtualPath method to modify the path that gets returned to the client.
    // e.g. you can prepend a domain, or append a query string:
    //      return "http://localhost" + path + "?foo=bar";
    private static string ProcessVirtualPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and must first be made absolute
        string path = VirtualPathUtility.ToAbsolute(virtualPath);
        
        // Add your own modifications here before returning the path
        return path;
    }

    private static string ProcessAssetPathDefault(string virtualPath) {
        // The path that comes in starts with ~/ and should retain this prefix
        return virtualPath;
    }

    // Calling ProcessVirtualPath through delegate to allow it to be replaced for unit testing
    public static Func<string, string> ProcessVirtualPath = ProcessVirtualPathDefault;
    public static Func<string, string> ProcessAssetPath = ProcessAssetPathDefault;

    // Calling T4Extension.TimestampString through delegate to allow it to be replaced for unit testing and other purposes
    public static Func<string, string> TimestampString = System.Web.Mvc.T4Extensions.TimestampString;

    // Logic to determine if the app is running in production or dev environment
    public static bool IsProduction() { 
        return (HttpContext.Current != null && !HttpContext.Current.IsDebuggingEnabled); 
    }
}





#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114


