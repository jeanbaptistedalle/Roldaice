using Roldaice.RollDice.Logic;
using Roldaice.Web.Models.RollDice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Controllers
{
    public partial class RollDiceController : BaseController
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        #region RollADice
        [HttpGet]
        public virtual ActionResult RollADice()
        {
            var model = new RollADiceModel()
            {
                DiceCode = Dice.D10().Code,
            };
            PrepareRollADiceModel(model);
            return View(MVC.RollDice.Views.RollADice, model);
        }
        [HttpPost]
        public virtual ActionResult RollADice(RollADiceModel model)
        {
            PrepareRollADiceModel(model);
            if (ModelState.IsValid)
            {
                var dice = Dice.GetByCode(model.DiceCode);
                var masteries = Mastery.None;
                if (model.Plus2)
                {
                    masteries &= Mastery.Plus2;
                }
                if (model.Average)
                {
                    masteries &= Mastery.Average;
                }
                if (model.TwoDice)
                {
                    masteries &= Mastery.TwoDice;
                }
                model.Result = dice.Roll(masteries);
            }
            return View(MVC.RollDice.Views.RollADice, model);
        }

        private void PrepareRollADiceModel(RollADiceModel model)
        {
            model.AvailableDices = SelectListItemHelper.GetDices();
        }
        #endregion RollADice
    }
}