using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roldaice.Cryptograph.Enigma
{
    public class Rotor
    {
        public string Code { get; private set; }
        public char TurnOverNotchLetter { get; private set; }
        public char StartingLetter { get; private set; }
        public Dictionary<char, char> Mapping { get; private set; }
        public char CurrentLetter { get; private set; }

        /// <summary>
        /// Create the rotor with the given configuration
        /// </summary>
        /// <param name="code"></param>
        /// <param name="turnOverNotchLetter"></param>
        /// <param name="mapping"></param>
        /// <param name="startingLetter"></param>
        private Rotor(string code, char turnOverNotchLetter, string mapping, char startingLetter)
        {
            Code = code;
            TurnOverNotchLetter = turnOverNotchLetter;
            StartingLetter = startingLetter;
            CurrentLetter = startingLetter;
            Mapping = new Dictionary<char, char>();
            var alphabet = AlphabetHelper.GetAlphabet().ToList();
            for (int idx = 0; idx < 26; idx++)
            {
                Mapping[alphabet[idx]] = mapping[idx];
            }
        }

        #region Rotors existing configuration
        public static Rotor I(char startingLetter)
        {
            //..........................ABCDEFGHIJKLMNOPQRSTUVWXYZ
            return new Rotor("I", 'Q', "EKMFLGDQVZNTOWYHXUSPAIBRCJ", startingLetter);
        }

        public static Rotor II(char startingLetter)
        {
            //...........................ABCDEFGHIJKLMNOPQRSTUVWXYZ
            return new Rotor("II", 'E', "AJDKSIRUXBLHWTMCQGZNPYFVOE", startingLetter);
        }

        public static Rotor III(char startingLetter)
        {
            //............................ABCDEFGHIJKLMNOPQRSTUVWXYZ
            return new Rotor("III", 'V', "BDFHJLCPRTXVZNYEIWGAKMUSQO", startingLetter);
        }

        public static Rotor IV(char startingLetter)
        {
            //...........................ABCDEFGHIJKLMNOPQRSTUVWXYZ
            return new Rotor("IV", 'J', "ESOVPZJAYQUIRHXLNFTGKDCMWB", startingLetter);
        }

        public static Rotor V(char startingLetter)
        {
            //..........................ABCDEFGHIJKLMNOPQRSTUVWXYZ
            return new Rotor("V", 'Z', "VZBRGITYUPSDNHLXAWMJQOFECK", startingLetter);
        }

        public static List<Rotor> GetAll()
        {
            return new List<Rotor>
            {
                Rotor.I('A'),
                Rotor.II('A'),
                Rotor.III('A'),
                Rotor.IV('A'),
                Rotor.V('A'),
            };
        }
        #endregion

        public char Encode(char character)
        {
            var offsetedCharacter = AlphabetHelper.GetNextChar(character, GetOffset());
            var mappedCharacter = Mapping[offsetedCharacter];
            return AlphabetHelper.GetNextChar(mappedCharacter, GetInverseOffset());
        }

        public char InverseEncode(char character)
        {
            var offsetedCharacter = AlphabetHelper.GetNextChar(character, GetOffset());
            var mappedCharacter = Mapping.Where(x => x.Value == offsetedCharacter).FirstOrDefault().Key;
            return AlphabetHelper.GetNextChar(mappedCharacter, GetInverseOffset());
        }

        /// <summary>
        /// Move the rotor to the next letter. If the current letter is the notch letter, the next rotor has to me move
        /// </summary>
        /// <returns>True if the next rotor has to be moved, false if hasn't </returns>
        public bool MoveRotor()
        {
            var moveNextRotor = TurnOverNotchLetter == CurrentLetter;
            CurrentLetter = AlphabetHelper.GetNextChar(CurrentLetter);
            return moveNextRotor;
        }

        public int GetOffset()
        {
            return CurrentLetter - 'A';
        }

        public int GetInverseOffset()
        {
            return 'A' - CurrentLetter;
        }
    }
}
