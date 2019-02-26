using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Roldaice.Web.Helpers
{
    public static class MvcHelper
    {
        public static RouteValueDictionary Attributes(this HtmlHelper html, object htmlAttributes, bool readOnly = false, bool disabled = false)
        {
            var _htlmAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (readOnly)
            {
                _htlmAttributes["readonly"] = "readonly";
            }
            if (disabled)
            {
                _htlmAttributes["disabled"] = "disabled";
            }
            return _htlmAttributes;
        }
    }
}