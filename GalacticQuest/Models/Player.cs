using System.Collections.Generic;
using System;
using GalacticQuest.Models;
using System.Linq;

namespace GalacticQuest
{
    public class Player
    {
        public int Hp { get; private set; } = 100;
        public int Attack { get; private set; } = 10;
        public List<Models.Item> Items { get; private set; } = new List<Models.Item>();

        public Player(int hp, int attack, List<Models.Item> items)
        {
            Hp = hp;
            Attack = attack;
            Items = items;
        }

        public Player(int hp, int attack)
        {
            Hp = hp;
            Attack = attack;
        }

        public Player(int hp)
        {
            Hp = hp;
        }

        public Player()
        {
        }

        public void UpdateHp(int hp)
        {
            Hp += hp;

            if (Hp <= 0)
            {
                Hp = 0;
                return;
            }
        }

        public void ShowProfile()
        {
            Console.WriteLine("Displaying Player Profile:");

            Console.WriteLine($"Player HP: {Hp}");
            Console.Write("\n");

            Console.WriteLine("Player Items: ");
            for (int index = 0; index < Items.Count; ++index)
            {
                Console.WriteLine($"Item -> Name: {Items[index].GetType().Name}" + " | " + $"Attack: {Items[index].AttackValue}");
            }
            Console.Write("\n");

            Console.WriteLine($"Player Attack: {Attack}");
            int playerTotalAttack = Attack;
            for (int index = 0; index < Items.Count; ++index)
            {
                int itemAttack = Items[index].AttackValue;

                playerTotalAttack += itemAttack;
            }
            Console.WriteLine($"Player Attack (Combined With Items Attack): {playerTotalAttack}");
            Console.Write("\n");
        }
    }
}