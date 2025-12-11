using System;

namespace GalacticQuest.Models
{
    internal class Tessaiga : Item
    {
        internal Tessaiga() : base(1000, 100)
        {
        }

        internal override void SpecialPower()
        {
            Console.WriteLine("Tessaiga performs a 'Wind Scar', protecting the user from harm!");
        }
    }
}