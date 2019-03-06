using NUnit.Framework;
using Roldaice.RollDice.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.RollDice.Logic.Tests
{
    [TestFixture()]
    public class DiceTests
    {
        [TestCase("D4", ExpectedResult = 2)]
        [TestCase("D6", ExpectedResult = 3)]
        [TestCase("D8", ExpectedResult = 4)]
        [TestCase("D10", ExpectedResult = 5)]
        [TestCase("D12", ExpectedResult = 6)]
        [TestCase("D20", ExpectedResult = 10)]
        [TestCase("D30", ExpectedResult = 15)]
        public int DiceAverage(string code)
        {
            return Dice.GetByCode(code).DiceAverage;
        }
    }
}