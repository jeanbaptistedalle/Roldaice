﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
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

        /// <summary>
        /// Importe le script demandé en forçant à le réimporter à chaque version
        /// </summary>
        /// <param name="path">Chemin du script à importer</param>
        /// <returns>Balise script avec la version</returns>
        public static IHtmlString RenderScriptWithVersion(string path)
        {
            var version = AppSettingsHelper.GetBuildVersion();
            return Scripts.RenderFormat("<script type=\"text/javascript\" src=\"{0}?v=" + version + "\"></script>", path);
        }

        /// <summary>
        /// Importe le style demandé en forçant à le réimporter à chaque version
        /// </summary>
        /// <param name="path">Chemin du style à importer</param>
        /// <returns>Balise link pour importer le style avec la version</returns>
        public static IHtmlString RenderStyleWithVersion(string path)
        {
            var version = AppSettingsHelper.GetBuildVersion();
            return Styles.RenderFormat("<link rel=\"stylesheet\" href=\"{0}?v=" + version + "\">", path);
        }
    }
}