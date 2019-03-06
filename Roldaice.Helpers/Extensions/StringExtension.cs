using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Helpers.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Renvoie la chaine en prenant maximum <length> caractères
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Take(this string source, int length)
        {
            #region parameters check
            if (source == null) { throw new ArgumentNullException(); }
            if (length <= 0) { throw new ArgumentOutOfRangeException("La longueur souhaitée doit être supérieure à 0"); }
            #endregion

            var result = source;

            if (source.Length > length)
            {
                result = source.Substring(0, length);
            }

            return result;
        }
    }
}
