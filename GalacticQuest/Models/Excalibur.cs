using System;

namespace GalacticQuest.Models
{
    internal class Excalibur : Item
    {
        internal Excalibur() : base(500, 50)
        {
        }

        internal override void SpecialPower()
        {
            Console.WriteLine("Excalibur unleashes the 'Light of the Lake' dealing extra damage!");
        }
    }
}