using Roldaice.Common.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Common.Dto
{
    public class UserCustomizationDto : DtoBase
    {        
        public string IdenticonSeed { get; set; }
        
        public string NavbarBackgroundColor { get; set; }
    }
}
