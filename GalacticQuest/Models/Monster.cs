using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticQuest.Models
{
    internal abstract class Monster
    {
        internal virtual  int Attack { get; set; } = 10;
        internal virtual int Hp { get; set; } = 100;
        internal virtual string Name { get; set; } = "Monster";
        
        internal Monster() {
            BattleCry();

        }
        internal abstract void BattleCry();
        internal abstract void OnDeath();



    }
}
