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

        public static int GetCookieDurationInHours()
        {
            int hours = 48;
            Int32.TryParse(ConfigurationManager.AppSettings[FrontAppSettingsKey.CookieDurationInHours], out hours);
            return hours;
        }

        public static string GetFacebookClientId()
        {
            return ConfigurationManager.AppSettings[FrontAppSettingsKey.FacebookClientId];
        }

        public static string GetFacebookClientSecret()
        {
            return ConfigurationManager.AppSettings[FrontAppSettingsKey.FacebookClientSecret];
        }
    }
}