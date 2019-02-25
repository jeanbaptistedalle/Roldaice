using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RoldaiceWeb.Models.Cryptograph
{
    public class EnigmaModel
    {
        public EnigmaModel()
        {
            WithRotation = true;
        }

        [DisplayName("Rotation ?")]
        public bool WithRotation { get; set; }
    }
}