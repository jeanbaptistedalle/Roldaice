using AutoMapper;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace RoldaiceWeb.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public ILogger Logger { get; set; }

        [Dependency]
        public IMapper Mapper { get; set; }
    }
}