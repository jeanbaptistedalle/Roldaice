using RoldaiceWeb.Models.Cryptograph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoldaiceWeb.Controllers
{
    public partial class CryptographController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult Enigma()
        {
            var model = new EnigmaModel();
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Enigma(EnigmaModel model)
        {
            return View(model);
        }
    }
}