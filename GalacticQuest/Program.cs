using System;
using System.Collections.Generic;
using System.Linq;

namespace GalacticQuest
{
    internal class Program
    {
      
        enum MainMenu
        {
            Monsters = 1,
            Travel,
            Journal,
            Exit
        }

        enum TravelOptions
        {
            Explore = 1,
            SearchForItems,
            BackToShip
        }

        enum JournalOptions
        {
            Monsters = 1,
            Planets,
            Items,
            Back
        }

        static void Main(string[] args)
        {
          
            var monsters = InitializeMonsters();
            bool isRunning = true;

            while (isRunning)
            {
                ShowMainMenu();

                string input = Console.ReadLine();
                int.TryParse(input, out int parsedInt);

                switch (parsedInt)
                {
                    case (int)MainMenu.Monsters:
                        
                        HandleMonstersMenu(monsters);
                        break;

                    case (int)MainMenu.Travel:
                      
                        HandleTravelMenu();
                        break;

                    case (int)MainMenu.Journal:
                       
                        HandleJournalMenu();
                        break;

                    case (int)MainMenu.Exit:
                        Console.WriteLine("Exiting the game. Goodbye, Captain!");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static Dictionary<string, (int Health, int Attack)> InitializeMonsters()
        {
            return new Dictionary<string, (int Health, int Attack)>()
            {
                { "Space Pirate", (150, 25) },
                { "Galactic Overlord", (300, 50) },
                { "Cosmic Beast", (250, 40) },
                { "Nebula Phantom", (200, 35) },
                { "Astro Wraith", (180, 30) },
                { "Stellar Serpent", (220, 38) },
                { "Void Reaper", (275, 45) }
            };
        }

      
        static void ShowMainMenu()
        {
        
            Console.WriteLine("GALACTIC QUEST - MAIN MENU");
            Console.WriteLine("Select One Option:");
            Console.WriteLine("1. Monsters");
            Console.WriteLine("2. Travel");
            Console.WriteLine("3. Journal");
            Console.WriteLine("4. Exit");
            Console.Write("Input: ");
        }

      
        static void HandleMonstersMenu(Dictionary<string, (int Health, int Attack)> monsters)
        {
            bool inMonsterMenu = true;
            while (inMonsterMenu)
            {

                foreach (var monster in monsters)
                {
                    Console.WriteLine($"Name: {monster.Key}, Health: {monster.Value.Health}, Attack: {monster.Value.Attack}");
                }
               
                Console.WriteLine("1. Filter by name");
                Console.WriteLine("2. Back to Main Menu");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter the name to filter: ");
                    string filterName = Console.ReadLine();

                    var filteredMonsters = monsters.Where(m => m.Key.Contains(filterName, StringComparison.OrdinalIgnoreCase));

                    Console.WriteLine(" Search Results :");
                    if (filteredMonsters.Any())
                    {
                        foreach (var monster in filteredMonsters)
                        {
                            Console.WriteLine($"Name: {monster.Key}, Health: {monster.Value.Health}, Attack: {monster.Value.Attack}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No monsters found.");
                        Console.WriteLine( "All Monsters :");
                        foreach (var monster in monsters)
                        {
                            Console.WriteLine($"Name: {monster.Key}, Health: {monster.Value.Health}, Attack: {monster.Value.Attack}");
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (choice == "2")
                {
                    inMonsterMenu = false;
                }
            }
        }

        static void HandleTravelMenu()
        {
            bool inTravelMenu = true;
            while (inTravelMenu)
            {
               
                Console.WriteLine("1. Explore");
                Console.WriteLine("2. Search For Items");
                Console.WriteLine("3. Back To Ship");
                Console.Write("Choice: ");

                string travelInput = Console.ReadLine();
                int.TryParse(travelInput, out int travelChoice);

                switch (travelChoice)
                {
                    case (int)TravelOptions.Explore:
                        Console.WriteLine("Selected Explore"); ;
                        Console.ReadKey();
                        break;
                    case (int)TravelOptions.SearchForItems:
                        Console.WriteLine("Selected Search For Items");
                        Console.ReadKey();
                        break;
                    case (int)TravelOptions.BackToShip:
                        inTravelMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid travel option.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // 5. Logica pentru Meniul Journal
        static void HandleJournalMenu()
        {
            bool inJournalMenu = true;
            while (inJournalMenu)
            {
               
                Console.WriteLine("1. Monsters");
                Console.WriteLine("2. Planets");
                Console.WriteLine("3. Items");
                Console.WriteLine("4. Back");
                Console.Write("Choice: ");

                string journalInput = Console.ReadLine();
                int.TryParse(journalInput, out int journalChoice);

                switch (journalChoice)
                {
                    case (int)JournalOptions.Monsters:
                        Console.WriteLine("Selected Monsters");
                        Console.ReadKey();
                        break;
                    case (int)JournalOptions.Planets:
                        Console.WriteLine("Selected Planets");
                        Console.ReadKey();
                        break;
                    case (int)JournalOptions.Items:
                        Console.WriteLine("Selected Items");
                        Console.ReadKey();
                        break;
                    case (int)JournalOptions.Back:
                        inJournalMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid journal option.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}