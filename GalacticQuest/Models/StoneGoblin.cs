using System;

namespace GalacticQuest.Models
{
    internal class StoneGoblin : Monster
    {
        internal override int Hp { get; set; } = 50;
        internal override int Attack { get; set; } = 5;
        internal override string Name { get; set; } = "StoneGoblin";

        internal override void BattleCry()
        {
            Console.WriteLine("StoneGoblin lets out a squeaky battle cry!");
        }

        internal override void OnDeath()
        {
            Console.WriteLine("StoneGoblin crumbles into dust!");
        }
    }
}