using NUnit.Framework;
using Cryptograph.Enigma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptograph.Enigma.Tests
{
    [TestFixture()]
    public class EnigmaCoreTests
    {
        [TestCase('A', ExpectedResult = 'F')]
        [TestCase('C', ExpectedResult = 'P')]
        [TestCase('H', ExpectedResult = 'M')]
        public char EncodeCharacter1(char character)
        {
            var enigma = new EnigmaCore(
                Reflector.UKWB(),
                Rotor.I('A'),
                Rotor.II('A'),
                Rotor.III('A')
            );
            var result = enigma.Encode(character);
            return result;
        }
        [TestCase('A', ExpectedResult = 'T')]
        [TestCase('C', ExpectedResult = 'Y')]
        [TestCase('H', ExpectedResult = 'P')]
        public char EncodeCharacter2(char character)
        {
            var enigma = new EnigmaCore(
                Reflector.UKWB(),
                Rotor.I('B'),
                Rotor.II('A'),
                Rotor.III('A')
            );
            var result = enigma.Encode(character);
            return result;
        }

        [TestCase("HELLOWORLD", ExpectedResult = "MFNCZBBFZM")]
        public string EncodeText(string text)
        {
            var enigma = new EnigmaCore(
                Reflector.UKWB(),
                Rotor.I('A'),
                Rotor.II('A'),
                Rotor.III('A')
            );
            var result = enigma.Encode(text);
            return result;
        }
    }
}