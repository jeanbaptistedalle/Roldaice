using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.RollDice.Logic
{
    public class Dice
    {
        private Dice(int maximum) : this($"D{maximum}", maximum) { }
        private Dice(string code, int maximum) : this(code, maximum, 1) { }

        private Dice(string code, int diceMaximum, int diceMinimum)
        {
            Code = code;
            _diceMaximum = diceMaximum;
            _diceMinimum = diceMinimum;
        }
        public string Code { get; private set; }
        private int _diceMinimum;
        public int DiceMinimum
        {
            get
            {
                return _diceMinimum;
            }
        }
        private int _diceMaximum;
        public int DiceMaximum
        {
            get
            {
                return _diceMaximum;
            }
        }
        private int _diceAverage => _diceMaximum / 2;
        public int DiceAverage
        {
            get
            {
                return _diceAverage;
            }
        }

        #region Dice configurations
        public static Dice D4()
        {
            return new Dice(4);
        }
        public static Dice D6()
        {
            return new Dice(6);
        }
        public static Dice D8()
        {
            return new Dice(8);
        }
        public static Dice D10()
        {
            return new Dice(10);
        }
        public static Dice D12()
        {
            return new Dice(12);
        }
        public static Dice D20()
        {
            return new Dice(20);
        }
        public static Dice D30()
        {
            return new Dice(30);
        }

        public static List<Dice> GetAll()
        {
            return new List<Dice>
            {
                D4(),
                D6(),
                D8(),
                D10(),
                D12(),
                D20(),
                D30(),
            };
        }

        public static Dice GetByCode(string code)
        {
            return GetAll().FirstOrDefault(x => x.Code == code);
        }
        #endregion Dice configurations

        public int Roll()
        {
            var random = new Random();
            var result = random.Next(DiceMinimum, DiceMaximum + 1);
            return result;
        }

        public int Roll(Mastery masteries)
        {
            var result = Roll();
            if (masteries.HasFlag(Mastery.TwoDice))
            {
                result = Math.Max(Roll(), result);
            }
            if (masteries.HasFlag(Mastery.Average))
            {
                if (result < DiceAverage)
                {
                    result = DiceAverage;
                }
            }
            if (masteries.HasFlag(Mastery.Plus2))
            {
                result += 2;
            }
            return result;
        }
    }
}
