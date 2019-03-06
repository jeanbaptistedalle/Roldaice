using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.RollDice.Logic
{
    [Flags]
    public enum Mastery
    {
        None = 0x0,
        TwoDice = 0x1,
        Plus2 = 0x2,
        Average = 0x3,
        Sidekick = 0x4,
        Contact = 0x5,        
    }
}
