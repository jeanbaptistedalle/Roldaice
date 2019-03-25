using Roldaice.Common.Dto;
using Roldaice.IDal.Interfaces.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.IDal.Dal
{
    public interface IUserDal : IBaseDal<UserDto>
    {
        UserDto GetByLoginPassword(string login, string password);
    }
}
