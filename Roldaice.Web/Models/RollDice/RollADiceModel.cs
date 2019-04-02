using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Models.RollDice
{
    public class RollADiceModel
    {
        [DisplayName("+2")]
        public bool Plus2 { get; set; }

        [DisplayName("2D")]
        public bool TwoDice { get; set; }

        [DisplayName("/2")]
        public bool Average { get; set; }

        [DisplayName("Type de dé")]
        public string DiceCode { get; set; }
        public List<SelectListItem> AvailableDices { get; set; }

        [DisplayName("Résultat")]
        public int? Result { get; set; }
    }
}