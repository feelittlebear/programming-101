 using System;
using System.Collections.Generic;

namespace MysticRealmsAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            // Create items
            Item crystalOfShadows = new Item("Crystal of Shadows", "A dark crystal found in the Haunted Forest.");
            Item crystalOfWater = new Item("Crystal of Water", "A blue crystal found in the Sunken City.");
            Item crystalOfAir = new Item("Crystal of Air", "A floating crystal found on the Floating Island.");
            Item phantomLantern = new Item("Phantom Lantern", "A lantern that reveals the unseen.");
            Item coralCrown = new Item("Coral Crown", "A crown made from deep sea corals.");
            Item featheredBoots = new Item("Feathered Boots", "Light boots that let you jump higher.");

            // Create NPCs
            Person npcForest = new Person("The Wandering Spirit");
            Person npcCity = new Person("The Ancient Guardian");
            Person npcIsland = new Person("The Sky Nomad");
            Person npcTemple = new Person("The Eternal Guardian");

            // Create locations
            Location hauntedForest = new Location("Haunted Forest", new List<Item> { phantomLantern, crystalOfShadows }, npcForest);
            Location sunkenCity = new Location("Sunken City", new List<Item> { coralCrown, crystalOfWater }, npcCity);
            Location floatingIsland = new Location("Floating Island", new List<Item> { featheredBoots, crystalOfAir }, npcIsland);
            Location forgottenTemple = new Location("Forgotten Temple", new List<Item> 
            {
                new Item("Temple Relic", "A mysterious relic of an ancient civilization."),
                new Item("Ancient Scroll", "A scroll with cryptic writing.")
            }, npcTemple);

            // Create player
            Person player = new Person("Adventurer");

            // Create world and add locations
            World world = new World(player);
            world.AddLocation(hauntedForest);
            world.AddLocation(sunkenCity);
            world.AddLocation(floatingIsland);
            world.AddLocation(forgottenTemple);

            // Game loop
            string command = "";
            while (command != "quit")
            {
                Console.WriteLine("Where would you like to go? (Haunted Forest, Sunken City, Floating Island, Forgotten Temple) or type 'quit' to exit.");
                command = Console.ReadLine()!;

                if (command != "quit")
                {
                    world.Travel(command);
                }
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
