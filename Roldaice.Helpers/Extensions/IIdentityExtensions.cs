using Roldaice.Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Helpers.Extensions
{
    public static class IIdentityExtensions
    {
        public static string GetIdenticonHash(this IIdentity identity)
        {
            var claimsIdentity = (identity as ClaimsIdentity);
            return claimsIdentity.Claims.SingleOrDefault(c => c.Type == CustomClaimTypes.IdenticonHash)?.Value;
        }
    }
}
