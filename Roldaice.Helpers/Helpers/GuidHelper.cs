using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Roldaice.Helpers.Extensions;

namespace Roldaice.Helpers.Helpers
{
    public sealed class GuidHelper
    {
        /// <summary>
        /// Génère un guid sous forme de chaine
        /// </summary>
        /// <returns></returns>
        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }


        /// <summary>
        /// Génère un guid Alpha (sans les caractères spéciaux)
        /// </summary>
        /// <returns></returns>
        public static string GenerateGuidAlpha()
        {
            var guid = GenerateGuid();
            return Regex.Replace(guid, @"[^0-9a-zA-Z]+", "");
        }

        /// <summary>
        /// Génère un guid Alpha (sans caractères spéciaux) de la taille demandée (dans la limite d'un guid)
        /// </summary>
        /// <param name="nbChar"></param>
        /// <returns></returns>
        public static string GenerateGuidAlpha(int nbChar)
        {
            var guid = GenerateGuidAlpha();
            return guid.Take(nbChar);
        }
    }
}
