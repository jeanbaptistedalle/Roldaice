using Roldaice.Web.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Roldaice.Web.Helpers
{
    /// <summary>
    /// Contains extension methods for MVC specifically designed for this website
    /// </summary>
    public static class MVCComponentHelper
    {
        public static MvcHtmlString AppIcon(this HtmlHelper html, string appText, ActionResult result, string htmlIconAttributes)
        {
            return AppIcon(html, appText, result, htmlIconAttributes, true);
        }
        public static MvcHtmlString AppIcon(this HtmlHelper html, string appText, ActionResult result, string htmlIconAttributes, bool visible)
        {
            if (!visible)
            {
                return MvcHtmlString.Empty;
            }
            var replaceMe = "replace_me";

            var iBuilder = new TagBuilder(HtmlConstants.ITag);
            iBuilder.MergeAttributes(new RouteValueDictionary(new { @class = htmlIconAttributes + " margin-top" }));
            string iHtml = iBuilder.ToString(TagRenderMode.Normal);

            var spanBuilder = new TagBuilder(HtmlConstants.SpanTag);
            spanBuilder.SetInnerText(appText);
            string spanHtml = spanBuilder.ToString(TagRenderMode.Normal);

            var preparedLinkText = $"{iHtml}{spanHtml}";
            var link = html.ActionLink(replaceMe, result, new { @class = CssClass.AppIcon });

            var divBuilder = new TagBuilder(HtmlConstants.DivTag);
            divBuilder.MergeAttributes(new RouteValueDictionary(new { @class = "col-xs-3" }));
            divBuilder.InnerHtml = link.ToString().Replace(replaceMe, preparedLinkText);
            string divHtml = divBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(divHtml);
        }
    }
}