using System;

namespace GalacticQuest.Models
{
    internal class HydraMax : Monster
    {
        internal override int Hp { get; set; } = 300;
        internal override int Attack { get; set; } = 40;
        internal override string Name { get; set; } = "HydraMax";

        internal override void BattleCry()
        {
            
            Console.WriteLine("HydraMax roars, showing its three terrifying heads!");
        }

        internal override void OnDeath()
        {
            Console.WriteLine("HydraMax's core shatters!");
        }
    }
}