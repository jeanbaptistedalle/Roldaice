using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Controllers
{
    public partial class ErrorController : BaseController
    {
        public virtual ViewResult NotFound()
        {
            return View(MVC.Shared.Views.Error404);
        }
    }
}