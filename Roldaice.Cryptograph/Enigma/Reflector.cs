using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Cryptograph.Enigma
{
    public class Reflector
    {
        public string Code { get; private set; }
        public Dictionary<char, char> Mapping { get; private set; }
        private Reflector(string code, string mapping)
        {
            Code = code;
            Mapping = new Dictionary<char, char>();
            var alphabet = AlphabetHelper.GetAlphabet().ToList();
            for(int idx = 0; idx < 26; idx++)
            {
                Mapping[alphabet[idx]] = mapping[idx];
            }
        }

        public char Reflect(char character)
        {
            return Mapping[character];
        }

        #region Reflector existing configuration
        public static Reflector UKWA()
        {
            //.............................ABCDEFGHIJKLMNOPQRSTUVWXYZ
            return new Reflector("UKX-A", "EJMZALYXVBWFCRQUONTSPIKHGD");
        }
        public static Reflector UKWB()
        {
            //.............................ABCDEFGHIJKLMNOPQRSTUVWXYZ
            return new Reflector("UKX-B", "YRUHQSLDPXNGOKMIEBFZCWVJAT");
        }
        public static Reflector UKWC()
        {
            //.............................ABCDEFGHIJKLMNOPQRSTUVWXYZ
            return new Reflector("UKX-C", "FVPJIAOYEDRZXWGCTKUQSBNMHL");
        }
        #endregion
    }
}
