using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Owin;
using Roldaice.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;

namespace Roldaice.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var cookieAuthenticationOptions = new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Authentication/Login"),
                ExpireTimeSpan = TimeSpan.FromHours(AppSettingsHelper.GetCookieDurationInHours())
            };

            app.UseCookieAuthentication(cookieAuthenticationOptions);

            //TODO Add facebook authentication
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //if (!string.IsNullOrEmpty(AppSettingsHelper.GetFacebookClientId()))
            //{
            //    app.UseFacebookAuthentication(new FacebookAuthenticationOptions()
            //    {
            //        AppId = AppSettingsHelper.GetFacebookClientId(),
            //        AppSecret = AppSettingsHelper.GetFacebookClientSecret(),
            //    });
            //}

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}