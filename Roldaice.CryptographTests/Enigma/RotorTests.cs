using NUnit.Framework;
using Roldaice.Cryptograph.Enigma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Cryptograph.Enigma.Tests
{
    [TestFixture()]
    public class RotorTests
    {
        [TestCase('Q', ExpectedResult = true)]
        [TestCase('A', ExpectedResult = false)]
        [TestCase('E', ExpectedResult = false)]
        [TestCase('Z', ExpectedResult = false)]
        public bool MoveRotorTestI(char startingLetter)
        {
            return Rotor.I(startingLetter).MoveRotor();
        }

        [TestCase('Q', ExpectedResult = false)]
        [TestCase('A', ExpectedResult = false)]
        [TestCase('E', ExpectedResult = true)]
        [TestCase('Z', ExpectedResult = false)]
        public bool MoveRotorTestII(char startingLetter)
        {
            return Rotor.II(startingLetter).MoveRotor();
        }

        [TestCase('A', 'A', ExpectedResult = 'E')]
        [TestCase('A', 'F', ExpectedResult = 'G')]
        [TestCase('A', 'Z', ExpectedResult = 'J')]

        [TestCase('B', 'A', ExpectedResult = 'J')]
        [TestCase('B', 'F', ExpectedResult = 'L')]
        [TestCase('B', 'Z', ExpectedResult = 'C')]
        public char EncodeTest(char startingLetter, char character)
        {
            return Rotor.I(startingLetter).Encode(character);
        }
    }
}