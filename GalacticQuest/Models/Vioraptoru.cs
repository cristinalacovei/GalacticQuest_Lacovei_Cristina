using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Models
{
    internal class Vioraptoru : Monster
    {
        internal override void BattleCry()
        {
            Console.WriteLine("Vioraptoru lets out a terrifying screech!");

        }

        internal override void OnDeath()
        {
           Console.WriteLine("Vioraptoru has been defeated!");
        }
    }
}
