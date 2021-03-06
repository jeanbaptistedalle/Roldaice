﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Roldaice.Helpers.Constants;
using Roldaice.Helpers.Extensions;
using Roldaice.IDal.Dal;
using Roldaice.Web.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Roldaice.Web.Controllers
{
    public partial class AccountController : BaseController
    {
        [Dependency]
        public IUserDal UserDal { get; set; }

        [HttpGet]
        public virtual ActionResult Login()
        {
            var model = new LoginModel();
            if (Request.UrlReferrer != null)
            {
                model.ReturnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);
            }
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserDal.GetByLoginPassword(model.Login, model.Password);
                if (user != null)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Login));
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.Label));

                    var seed = String.IsNullOrEmpty(user?.UserCustomization?.IdenticonSeed) ? user.Login : user?.UserCustomization?.IdenticonSeed;
                    identity.AddClaim(new Claim(CustomClaimTypes.IdenticonHash, seed.ToSHA256()));
                    identity.AddClaim(new Claim(CustomClaimTypes.UserThemeColor, user?.UserCustomization?.NavbarBackgroundColor ?? String.Empty));

                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = model.IsPersistent }, identity);

                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToHome();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "L'identifiant et/ou le mot de passe est invalide.");
                }
            }
            return View(model);
        }

        public virtual ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
            return RedirectToHome();
        }

        [HttpGet]
        public virtual ActionResult EditAccountSettings()
        {
            return View();
        }

        /*[HttpPost]
        public ActionResult EditAccountSettings()
        {
            return View();
        }*/
    }
}