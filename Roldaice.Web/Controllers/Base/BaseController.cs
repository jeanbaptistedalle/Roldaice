using AutoMapper;
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
    }
}