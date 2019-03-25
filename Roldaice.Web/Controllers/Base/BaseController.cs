using AutoMapper;
using Microsoft.Owin.Security;
using Roldaice.Helpers.Logger;
using Roldaice.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Roldaice.Web.Controllers
{
    public abstract partial class BaseController : Controller
    {
        [Dependency]
        public IMapper Mapper { get; set; }

        [Dependency]
        public ILogger Logger { get; set; }

        [Dependency]
        public SelectListItemHelper SelectListItemHelper { get; set; }

        public IAuthenticationManager AuthenticationManager => Request.GetOwinContext().Authentication;

        public virtual ActionResult RedirectToHome()
        {
            //FIXME : Can't use directly RedirectToAction(MVC.Home.Index()) because this method is not generated for abstract controller
            return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
        }
    }
}