using Roldaice.Cryptograph.Enigma;
using Roldaice.Web.Models.Cryptograph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Controllers
{
    public partial class CryptographController : BaseController
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        #region Enigma
        [HttpGet]
        public virtual ActionResult Enigma()
        {
            var model = new EnigmaModel();
            PrepareEnigmaModel(model);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Enigma(EnigmaModel model)
        {
            PrepareEnigmaModel(model);
            /*if (ModelState.IsValid)
            {
                var enigmaCore = new EnigmaCore(Reflector.UKWC, );
                model.Result = enigmaCore.Encode(model.Text);
            }*/
            return View(model);
        }

        private void PrepareEnigmaModel(EnigmaModel model)
        {
            model.AvailableRotors = SelectListItemHelper.GetRotors();
        }
        #endregion Enigma
    }
}