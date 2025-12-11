using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Models
{
    internal class Tinelatoru: Monster
    {
        internal override int Attack { get; set; } = 25;
        internal override string Name { get; set; } = "Tinel";
        internal override void BattleCry()
        {
            Console.WriteLine("Tinelatoru emits a low growl, shaking the ground!");
        }
        internal override void OnDeath()
        {
            Console.WriteLine("Tinelatoru collapses with a thunderous crash!");
        }

    }
}
