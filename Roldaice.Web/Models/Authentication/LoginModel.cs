using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Roldaice.Web.Models.Authentication
{
    public class LoginModel
    {
        [DisplayName("Identifiant")]
        public string Login { get; set; }

        [DisplayName("Mot de passe")]
        public string Password { get; set; }

        [DisplayName("Se souvenir de moi")]
        public bool IsPersistent { get; set; }
    }
}