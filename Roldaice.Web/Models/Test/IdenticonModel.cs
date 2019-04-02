using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Roldaice.Web.Models.Test
{
    public class IdenticonModel
    {
        [DisplayName("Seed")]
        public string Seed { get; set; }

        [DisplayName("Hash")]
        public string Hash { get; set; }
    }
}