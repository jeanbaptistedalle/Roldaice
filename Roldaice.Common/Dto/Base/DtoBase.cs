using Roldaice.ICommon.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Common.Dto.Base
{
    public abstract class DtoBase : IDtoBase
    {
        public int Id { get; set; }
    }
}
