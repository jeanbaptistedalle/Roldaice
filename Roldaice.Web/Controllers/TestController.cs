using Roldaice.Helpers.Extensions;
using Roldaice.Web.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Controllers
{
    public partial class TestController : BaseController
    {
        public virtual ViewResult Index()
        {
            return View();
        }

        public virtual ViewResult LoadingScreen()
        {
            return View();
        }

        [HttpGet]
        public virtual ViewResult Identicon()
        {
            var model = new IdenticonModel();
            if (User.Identity.IsAuthenticated)
            {
                model.Seed = User.Identity.Name;
            }
            return View(model);
        }

        [HttpPost]
        public virtual ViewResult Identicon(IdenticonModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Seed != null)
                {
                    model.Hash = model.Seed.ToSHA256();
                }
            }
            return View(model);
        }
    }
}