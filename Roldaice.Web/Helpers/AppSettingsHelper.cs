using Roldaice.Web.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Roldaice.Web.Helpers
{
    public class AppSettingsHelper
    {
        public static string GetBuildVersion()
        {
            return ConfigurationManager.AppSettings[FrontAppSettingsKey.BuildVersion];
        }
    }
}