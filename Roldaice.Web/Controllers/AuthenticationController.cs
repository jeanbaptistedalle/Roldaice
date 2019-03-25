using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Roldaice.IDal.Dal;
using Roldaice.Web.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Roldaice.Web.Controllers
{
    public partial class AuthenticationController : BaseController
    {
        [Dependency]
        public IUserDal UserDal { get; set; }

        [HttpGet]
        public virtual ActionResult Login()
        {
            var model = new LoginModel();
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
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = model.IsPersistent }, identity);

                    //TODO redirect to return url
                    return RedirectToHome();
                }
            }
            return View(model);
        }
        
        public virtual ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie, DefaultAuthenticationTypes.ExternalCookie);
            return RedirectToHome();
        }
    }
}