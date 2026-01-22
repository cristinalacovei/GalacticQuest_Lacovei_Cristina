
using GalacticQuest.Items;
using GalacticQuest.Monsters;

namespace GalacticQuest.Planets
{
   internal static class PlanetHelper
   {
        internal static readonly IList<IPlanet> PLANETS_LIST = new List<IPlanet>()
      {
          new PlanetMeridian(),
          new PlanetNibiru(),
          new PlanetVespera()
      };
        internal static readonly Random RandomNumberGenerator = new Random();

      private const int ITEM_DROP_PROBABILITY_FROM_PLANET = 35;

      private static int _currentPlanetIndex = -1;

        /// <summary>
        /// Selects a random planet and updates the current location.
        /// Call this when entering the Travel menu.
        /// </summary>
        internal static void TravelToRandomPlanet()
        {
            int randomPlanetIndex = RandomNumberGenerator.Next(0, PLANETS_LIST.Count);
            _currentPlanetIndex = randomPlanetIndex;
            IPlanet chosenPlanet = PLANETS_LIST[randomPlanetIndex];

            Console.WriteLine("Engaging Hyper-drive...");
            Console.WriteLine($"You arrived at planet: {chosenPlanet.GetType().Name.Split('.').Last()}");
        }

        /// <summary>
        /// Explores the current planet to find a monster and initiates combat.
        /// Call this when selecting "Explore".
        /// </summary>
        internal static void ExplorePlanet()
        {
            if (_currentPlanetIndex == -1)
            {
                Console.WriteLine("You are floating in space! Travel to a planet first.");
                return;
            }

            IPlanet currentPlanet = PLANETS_LIST[_currentPlanetIndex];
            Monster? randomMonster = ChooseRandomMonsterFromPlanet(currentPlanet);

            if (randomMonster is null)
            {
                Console.WriteLine("Unfortunately no monsters live on this planet :( ");
                return;
            }

            Console.WriteLine($"You have encountered a {randomMonster.GetType().Name.Split('.').Last()} named {randomMonster.Name} (HP: {randomMonster.Hp}, Attack: {randomMonster.Attack})");

            // Start the battle simulation
            PerformSimpleBattle(randomMonster);
        }

        /// <summary>
        /// Simulates a simple dice-roll battle based on attack power.
        /// </summary>
        private static void PerformSimpleBattle(Monster monster)
        {
            Console.WriteLine("\n--- BATTLE STARTED ---");

            // Generate random numbers from 0 to Attack (inclusive)
            // Random.Next(min, max) is exclusive on the upper bound, so we add 1
            int playerRoll = RandomNumberGenerator.Next(0, Program.currentPlayer.Attack + 1);
            int monsterRoll = RandomNumberGenerator.Next(0, monster.Attack + 1);

            Console.WriteLine($"Player rolls: {playerRoll} (Max Potential: {Program.currentPlayer.Attack})");
            Console.WriteLine($"{monster.Name} rolls: {monsterRoll} (Max Potential: {monster.Attack})");

            if (playerRoll > monsterRoll)
            {
                Console.WriteLine("Victory! Your attack overpowered the monster!");
            }
            else if (monsterRoll > playerRoll)
            {
                Console.WriteLine("Defeat! The monster's attack was stronger.");
            }
            else
            {
                Console.WriteLine("Stalemate! Both attacks clashed with equal force.");
            }

            Console.WriteLine("--- BATTLE ENDED ---\n");
        }

        /// <summary>
        /// Searches for a random item/s and displays what item/s the player received
        /// </summary>
        internal static void SearchForItems()
      {
         int randomProbability = RandomNumberGenerator.Next(0, 100);

         if (randomProbability < ITEM_DROP_PROBABILITY_FROM_PLANET)
         {
            Console.WriteLine("Sorry! No item found on this planet right now !");
            return;
         }

         Item? foundItem = ChooseRandomItemFromPlanet(PLANETS_LIST.ElementAtOrDefault(_currentPlanetIndex));
         if (foundItem is null)
         {
            Console.WriteLine("Sorry! No item found on this planet right now !");
            return;
         }

         Program.currentPlayer.AddItemToBackpack(foundItem);
         Console.WriteLine($"Congrats! You picked up a new item : {foundItem.Name} with Attack - {foundItem.Attack} and Resistance - {foundItem.Resitance}");
      }
      

      /// <summary>
      /// Picks a random monster found on that specific planet
      /// </summary>
      /// <param name="planet"> The planet on which to find monsters </param>
      /// <returns> The found monster, otherwise null </returns>
      private static Monster? ChooseRandomMonsterFromPlanet(IPlanet planet)
      {
         IList<Monster> monstersOnPlanet = planet?.GetInhabitants();

         if (monstersOnPlanet is null || monstersOnPlanet.Count < 1)
         {
            return null;
         }

         return monstersOnPlanet.ElementAtOrDefault(RandomNumberGenerator.Next(0, monstersOnPlanet.Count));
      }

      /// <summary>
      /// Picks a random item (with a random chance of dropping) from the specified planet
      /// </summary>
      /// <param name="planet"> The planet from which to choose a random item </param>
      /// <returns> The found item, otherwise null </returns>
      private static Item? ChooseRandomItemFromPlanet(IPlanet planet)
      {
         IList<Item> itemsOnPlanet = planet?.GetAvailableItems();

         if(itemsOnPlanet is null || itemsOnPlanet.Count < 1)
         {
            return null;
         }

         return itemsOnPlanet.ElementAtOrDefault(RandomNumberGenerator.Next(0, itemsOnPlanet.Count));
      }
   }
}
