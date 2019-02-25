using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptograph.Enigma
{
    public class AlphabetHelper
    {
        public static IEnumerable<char> GetAlphabet()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                yield return c;
            }
        }

        public static int GetIndexFromChar(char character)
        {
            return character - (int)'A';
        }

        public static char GetCharFromIndex(int idx)
        {
            return (char)('A' + idx);
        }

        public static char GetNextChar(char character)
        {
            return GetNextChar(character, 1);
        }

        public static char GetNextChar(char character, int offset)
        {
            return GetCharFromIndex(Modulo(GetIndexFromChar(character) + offset, 26));
        }

        public static int Modulo(int number, int modulo)
        {
            return number >= 0 ? number % modulo : modulo - 1 - ((-number - 1) % modulo);
        }

    }
}
