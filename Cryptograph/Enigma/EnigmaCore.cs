using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Cryptograph.Enigma
{
    public class EnigmaCore
    {
        public List<Rotor> Rotors { get; private set; }
        public Reflector Reflector { get; private set; }

        /// <summary>
        /// Create an enigma engine with the given configurations for the rotors
        /// </summary>
        /// <param name="rotors">Rotors</param>
        public EnigmaCore(Reflector reflector, params Rotor[] rotors)
        {
            Reflector = reflector ?? throw new ArgumentNullException(nameof(reflector));

            if (rotors == null)
            {
                throw new ArgumentNullException(nameof(rotors));
            }
            if (rotors.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rotors), "The engine need at least one rotor");
            }
            if (rotors.GroupBy(x => x.Code).Any(x => x.Count() > 1))
            {
                throw new ArgumentException(nameof(rotors), "The rotor's configurations has to be different (ex : I, II, III)");
            }
            Rotors = rotors.ToList();
        }

        public string Encode(string text, bool moveRotor = true)
        {
            var builder = new StringBuilder();
            foreach (var character in text)
            {
                builder.Append(Encode(character, moveRotor));
            }
            return builder.ToString();
        }

        public char Encode(char character, bool moveRotor = true)
        {
            if (!char.IsLetter(character))
            {
                return character;
            }
            if (moveRotor)
            {
                MoveRotors();
            }

            var encodedCharacter = character;
            foreach (var rotor in Rotors)
            {
                encodedCharacter = rotor.Encode(encodedCharacter);
            }
            encodedCharacter = Reflector.Reflect(encodedCharacter);
            foreach (var rotor in Rotors.AsEnumerable().Reverse())
            {
                encodedCharacter = rotor.InverseEncode(encodedCharacter);
            }

            return encodedCharacter;
        }

        private void MoveRotors()
        {
            var moveNextRotor = true;
            var currentRotorIndex = 0;
            while (moveNextRotor && currentRotorIndex < Rotors.Count)
            {
                moveNextRotor = Rotors[currentRotorIndex++].MoveRotor();
            }
        }
    }
}
