using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.Models.Cryptograph
{
    public class EnigmaModel : IValidatableObject
    {
        public EnigmaModel()
        {
            MoveRotor = true;
            SelectedRotor1 = "I";
            SelectedRotor2 = "II";
            SelectedRotor3 = "III";
            StartingLetter1 = 'A';
            StartingLetter2 = 'A';
            StartingLetter3 = 'A';
        }

        [DisplayName("Texte à chiffrer")]
        [Required(AllowEmptyStrings = false)]
        public string Text { get; set; }

        [DisplayName("Résultat")]
        public string Result { get; set; }

        [DisplayName("Rotation des rotors ?")]
        public bool MoveRotor { get; set; }

        [DisplayName("Rotor 1")]
        [Required(AllowEmptyStrings = false)]
        public string SelectedRotor1 { get; set; }

        [DisplayName("Lettre de départ rotor 1")]
        [Required(AllowEmptyStrings = false)]
        public char StartingLetter1 { get; set; }

        [DisplayName("Rotor 2")]
        [Required(AllowEmptyStrings = false)]
        public string SelectedRotor2 { get; set; }

        [DisplayName("Lettre de départ rotor 2")]
        [Required(AllowEmptyStrings = false)]
        public char StartingLetter2 { get; set; }

        [DisplayName("Rotor 3")]
        [Required(AllowEmptyStrings = false)]
        public string SelectedRotor3 { get; set; }

        [DisplayName("Lettre de départ rotor 3")]
        [Required(AllowEmptyStrings = false)]
        public char StartingLetter3 { get; set; }

        public List<SelectListItem> AvailableRotors { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SelectedRotor1 == SelectedRotor2 || SelectedRotor2 == SelectedRotor3 || SelectedRotor3 == SelectedRotor1)
            {
                yield return new ValidationResult("Les rotors doivent être différents. Un même rotor n'est utilisable qu'une seule fois.");
            }
        }
    }
}