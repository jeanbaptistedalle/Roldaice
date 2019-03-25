using Roldaice.Common.Dto;
using Roldaice.Dal.Dal.Base;
using Roldaice.Dal.Entities;
using Roldaice.Helpers.Extensions;
using Roldaice.IDal.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Dal.Dal
{
    public class UserDal : EntityDalBase<User, UserDto>, IUserDal
    {
        /// <summary>
        /// Return the user if it match with the given login and password
        /// </summary>
        /// <param name="login">Login of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns>User if one match or null</returns>
        public UserDto GetByLoginPassword(string login, string password)
        {
            var user = Repository().SingleOrDefault(x => x.Login == login);
            if (user != null && user.Password == password.ToSHA256(user.Salt))
            {
                return ToDto(user);
            }
            return null;
        }
    }
}
