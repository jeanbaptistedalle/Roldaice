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
            if (ModelState.IsValid)
            {
                var rotors = new List<Rotor>
                {
                    Rotor.GetByCode(model.SelectedRotor1, model.StartingLetter1),
                    Rotor.GetByCode(model.SelectedRotor2, model.StartingLetter2),
                    Rotor.GetByCode(model.SelectedRotor3, model.StartingLetter3),
                };
                var enigmaCore = new EnigmaCore(Reflector.UKWB(), rotors.ToArray());
                model.Result = enigmaCore.Encode(model.Text, model.MoveRotor);
            }
            return View(model);
        }

        private void PrepareEnigmaModel(EnigmaModel model)
        {
            model.AvailableRotors = SelectListItemHelper.GetRotors();
        }
        #endregion Enigma
    }
}