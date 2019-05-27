// <auto-generated />
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
namespace T4MVC
{
    public class SharedController
    {

        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string Error = "Error";
                public readonly string Error404 = "Error404";
            }
            public readonly string Error = "~/Views/Shared/Error.cshtml";
            public readonly string Error404 = "~/Views/Shared/Error404.cshtml";
            static readonly _DisplayTemplatesClass s_DisplayTemplates = new _DisplayTemplatesClass();
            public _DisplayTemplatesClass DisplayTemplates { get { return s_DisplayTemplates; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _DisplayTemplatesClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                }
            }
            static readonly _EditorTemplatesClass s_EditorTemplates = new _EditorTemplatesClass();
            public _EditorTemplatesClass EditorTemplates { get { return s_EditorTemplates; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _EditorTemplatesClass
            {
                public readonly string Boolean = "Boolean";
            }
            static readonly _LayoutClass s_Layout = new _LayoutClass();
            public _LayoutClass Layout { get { return s_Layout; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _LayoutClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string _Layout = "_Layout";
                    public readonly string _MiniPanelLayout = "_MiniPanelLayout";
                    public readonly string _PanelCollapsePanel = "_PanelCollapsePanel";
                    public readonly string _PanelLayout = "_PanelLayout";
                }
                public readonly string _Layout = "~/Views/Shared/Layout/_Layout.cshtml";
                public readonly string _MiniPanelLayout = "~/Views/Shared/Layout/_MiniPanelLayout.cshtml";
                public readonly string _PanelCollapsePanel = "~/Views/Shared/Layout/_PanelCollapsePanel.cshtml";
                public readonly string _PanelLayout = "~/Views/Shared/Layout/_PanelLayout.cshtml";
                static readonly _PartialClass s_Partial = new _PartialClass();
                public _PartialClass Partial { get { return s_Partial; } }
                [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
                public partial class _PartialClass
                {
                    static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                    public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                    public class _ViewNamesClass
                    {
                        public readonly string _AppList = "_AppList";
                        public readonly string _JavascriptConstants = "_JavascriptConstants";
                        public readonly string _Loader = "_Loader";
                        public readonly string _NavBar = "_NavBar";
                        public readonly string _Url = "_Url";
                        public readonly string _UserTheme = "_UserTheme";
                    }
                    public readonly string _AppList = "~/Views/Shared/Layout/Partial/_AppList.cshtml";
                    public readonly string _JavascriptConstants = "~/Views/Shared/Layout/Partial/_JavascriptConstants.cshtml";
                    public readonly string _Loader = "~/Views/Shared/Layout/Partial/_Loader.cshtml";
                    public readonly string _NavBar = "~/Views/Shared/Layout/Partial/_NavBar.cshtml";
                    public readonly string _Url = "~/Views/Shared/Layout/Partial/_Url.cshtml";
                    public readonly string _UserTheme = "~/Views/Shared/Layout/Partial/_UserTheme.cshtml";
                }
            }
            static readonly _PartialClass s_Partial = new _PartialClass();
            public _PartialClass Partial { get { return s_Partial; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _PartialClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string _EmptyView = "_EmptyView";
                    public readonly string _Strobe = "_Strobe";
                }
                public readonly string _EmptyView = "~/Views/Shared/Partial/_EmptyView.cshtml";
                public readonly string _Strobe = "~/Views/Shared/Partial/_Strobe.cshtml";
            }
            static readonly _PartialLayoutClass s_PartialLayout = new _PartialLayoutClass();
            public _PartialLayoutClass PartialLayout { get { return s_PartialLayout; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _PartialLayoutClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string _MiniPanelCollapsePanel = "_MiniPanelCollapsePanel";
                    public readonly string _MiniPanelLayout = "_MiniPanelLayout";
                    public readonly string _PanelCollapsePanel = "_PanelCollapsePanel";
                    public readonly string _PanelLayout = "_PanelLayout";
                }
                public readonly string _MiniPanelCollapsePanel = "~/Views/Shared/PartialLayout/_MiniPanelCollapsePanel.cshtml";
                public readonly string _MiniPanelLayout = "~/Views/Shared/PartialLayout/_MiniPanelLayout.cshtml";
                public readonly string _PanelCollapsePanel = "~/Views/Shared/PartialLayout/_PanelCollapsePanel.cshtml";
                public readonly string _PanelLayout = "~/Views/Shared/PartialLayout/_PanelLayout.cshtml";
            }
        }
    }

}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
