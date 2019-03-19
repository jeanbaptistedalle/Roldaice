using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public static string ToSHA256(this string source, string salt)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(source + salt));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
