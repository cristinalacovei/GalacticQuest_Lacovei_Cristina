using System;

namespace GalacticQuest.Models
{
    public abstract class Item
    {
        internal virtual int AttackValue { get; set; }

        internal virtual int HealthValue { get; set; }

        internal abstract void SpecialPower();

        internal Item(int attack, int health)
        {
            AttackValue = attack;
            HealthValue = health;
        }

        internal Item() { }
    }
}