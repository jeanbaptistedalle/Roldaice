using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Models.Cryptograph
{
    public class EnigmaModel
    {
        public EnigmaModel()
        {
            WithRotation = true;
            SelectedRotor1 = "I";
            SelectedRotor2 = "II";
            SelectedRotor3 = "III";
            StartingLetter1 = "A";
            StartingLetter2 = "A";
            StartingLetter3 = "A";
        }

        [DisplayName("Texte à chiffrer")]
        public string Text { get; set; }

        [DisplayName("Résultat")]
        public string Result { get; set; }

        [DisplayName("Rotation des rotors ?")]
        public bool WithRotation { get; set; }

        [DisplayName("Rotor 1")]
        public string SelectedRotor1 { get; set; }

        public string StartingLetter1 { get; set; }

        [DisplayName("Rotor 2")]
        public string SelectedRotor2 { get; set; }

        public string StartingLetter2 { get; set; }

        [DisplayName("Rotor 3")]
        public string SelectedRotor3 { get; set; }

        public string StartingLetter3 { get; set; }

        public List<SelectListItem> AvailableRotors { get; set; }
    }
}