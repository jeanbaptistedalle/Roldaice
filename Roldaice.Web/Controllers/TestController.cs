using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Controllers
{
    public partial class TestController : BaseController
    {
        public virtual ViewResult LoadingScreen()
        {
            return View(MVC.Test.Views.LoadingScreen);
        }
    }
}