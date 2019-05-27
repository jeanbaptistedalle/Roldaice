using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Controllers
{
    public partial class JdrController : BaseController
    {
        public virtual ActionResult CopsBiMaster()
        {
            return View();
        }
    }
}