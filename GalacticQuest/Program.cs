using System;
using System.Collections.Generic;
using System.Linq;
using GalacticQuest.Models;

namespace GalacticQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Galactic Quest!");

            CreateAndDisplayPlayerStats();

            CreateAndDisplayMonsterStats();

            OpenMainMenu();
        }

        internal static void CreateAndDisplayMonsterStats()
        {
            List<Models.Monster> monsters = new List<Models.Monster>()
            {
                new Models.Vioraptoru(),
                new Models.Tinelatoru()
            };

            foreach (var monster in monsters)
            {
                Console.Write("\n");

                Console.WriteLine($"Monster Name: {monster.Name}");
                Console.WriteLine($"Monster HP: {monster.Hp}");
                Console.WriteLine($"Monster Attack: {monster.Attack}");
                monster.OnDeath();
                Console.Write("\n");
            }
        }

        private static void CreateAndDisplayPlayerStats()
        {
            Console.Write("\n");

            List<Models.Item> items = new List<Models.Item>()
            {
                new Models.Excalibur(),
                new Models.Tessaiga()
            };

            Player player = new Player(50, 1, items);

            player.ShowProfile();

            player.UpdateHp(-60);
            Console.WriteLine($"After updating HP: {player.Hp}");
        }

        internal static void OpenMainMenu()
        {
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.Write("\n");
                Console.WriteLine("Select your option and press Enter: \n 1.Travel \n 2.Journal \n 3.Exit \n");
                int.TryParse(Console.ReadLine(), out int readOption);

                switch (readOption)
                {
                    case (int)GameOptions.Monsters:
                        OpenTravelMenu();
                        break;

                    case (int)GameOptions.Journal:
                        OpenJournalMenu();
                        break;

                    case (int)GameOptions.Exit:
                        isAppRunning = false;
                        break;

                    default:
                        Console.WriteLine("-_-' Invalid Option");
                        break;
                }
            }
        }

        internal enum GameOptions
        {
            Monsters = 1,
            Journal = 2,
            Exit = 3
        }

        internal static void OpenTravelMenu()
        {
            Console.Write("\n");
            Console.WriteLine("Select your option and press Enter: \n 1.Explore \n 2.Search For Items \n 3.Back To Ship \n 4.Back To Main Menu\n");

            int.TryParse(Console.ReadLine(), out int readOption);

            switch (readOption)
            {
                case 1:
                    Console.WriteLine("Selected Explore");
                    break;

                case 2:
                    Console.WriteLine("Selected Search For Items");
                    break;

                case 3:
                    Console.WriteLine("Selected Back To Ship");
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;
            }
        }

        internal static void OpenJournalMenu()
        {
            Console.Write("\n");
            Console.WriteLine("Select your option and press Enter: \n 1.Monsters \n 2.Planets \n 3.Items \n 4.Back To Main Menu\n");

            int.TryParse(Console.ReadLine(), out int readOption);

            switch (readOption)
            {
                case 1:
                    List<Models.Monster> allMonsters = CreateMonstersList();
                    ShowMonsters(allMonsters);
                    break;

                case 2:
                    Console.WriteLine("Selected Planets");
                    break;

                case 3:
                    Console.WriteLine("Selected Items");
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;
            }
        }

        internal static List<Models.Monster> CreateMonstersList()
        {
            List<Models.Monster> monsters = new List<Models.Monster>()
            {
                new Models.Vioraptoru(),
                new Models.Tinelatoru(),
                new Models.HydraMax(),
                new Models.StoneGoblin()
            };
            return monsters;
        }

        internal static void ShowMonsters(List<Models.Monster> monsters)
        {
            Console.WriteLine("The monsters are: ");

            for (int index = 0; index < monsters.Count; ++index)
            {
                Console.WriteLine($"{monsters[index].Name} - {monsters[index].Hp} HP - {monsters[index].Attack} ATT");
            }
            Console.Write("\n");

            ShowMonstersOptions(monsters);
        }

        internal static void ShowMonstersOptions(List<Models.Monster> monsters)
        {
            Console.WriteLine("Press 1 to go back or 2 to filter monsters based on name");

            int.TryParse(Console.ReadLine(), out int userOption);
            switch (userOption)
            {
                case 1:
                    break;
                case 2:
                    FilterMonstersByName(monsters);
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please try a valid option.");
                    break;
            }
        }

        internal static void FilterMonstersByName(List<Models.Monster> monsters)
        {
            Console.WriteLine("Enter letters to filter monsters: ");
            string? userInput = Console.ReadLine();

            Console.Write("\n");

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("No input provided. Showing all monsters.");
                Console.Write("\n");
                ShowMonsters(monsters);
                return;
            }

            string lowerCasedUserInput = userInput.ToLower();

            List<Models.Monster> filteredMonsters = monsters
                                                     .Where(m => m.Name.ToLower().Contains(lowerCasedUserInput))
                                                     .ToList();

            if (filteredMonsters.Count == 0)
            {
                Console.WriteLine("None of the monsters contain these letters.");
                Console.Write("\n");
            }
            else
            {
                for (int index = 0; index < filteredMonsters.Count; ++index)
                {
                    Console.WriteLine($"{filteredMonsters[index].Name} - {filteredMonsters[index].Hp} HP - {filteredMonsters[index].Attack} ATT");
                }
                Console.Write("\n");
            }
        }
    }
}