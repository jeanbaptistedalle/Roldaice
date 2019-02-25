using Roldaice.Cryptograph.Enigma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Cryptograph
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new EnigmaCore(
                Reflector.UKWB(),
                Rotor.I('L'),
                Rotor.II('U'),
                Rotor.III('C')
            );
            var text = "NOMINA SI NESCIS, PERIT ET COGNITIO RERUM";
            var encoded = core.Encode(text, moveRotor: false);
            var decoded = core.Encode(encoded, moveRotor: false);
            Console.WriteLine($"{text} > {encoded} > {decoded}");
            Console.ReadKey();
        }
    }
}
