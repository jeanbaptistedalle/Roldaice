using Roldaice.Common.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Common.Dto
{
    public class UserDto : DtoBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime CreationDate { get; set; }
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}
