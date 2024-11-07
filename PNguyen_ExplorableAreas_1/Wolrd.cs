using System;
using System.Collections.Generic;

namespace MysticRealmsAdventure
{
    // World class to manage the game
    class World
    {
        public List<Location> Locations { get; set; }
        public Person Player { get; set; }

        public World(Person player)
        {
            Player = player;
            Locations = new List<Location>();
        }

        public void AddLocation(Location location)
        {
            Locations.Add(location);
        }

        public void Travel(string locationName)
        {
            Location? location = Locations.Find(l => l.Name == locationName);

            if (location != null)
            {
                if (locationName == "Forgotten Temple")
                {
                    // Check if player has all three crystals before allowing entry
                    if (Player.HasItem("Crystal of Shadows") && Player.HasItem("Crystal of Water") && Player.HasItem("Crystal of Air"))
                    {
                        Console.WriteLine("You have all the required crystals. You may enter the Forgotten Temple.");
                        location.Explore(Player); // Proceed with exploring the temple
                    }
                    else
                    {
                        // Inform the player what items they are missing
                        Console.WriteLine("You cannot enter the Forgotten Temple. You are missing the following required crystals:");

                        if (!Player.HasItem("Crystal of Shadows"))
                        {
                            Console.WriteLine("- Crystal of Shadows");
                        }

                        if (!Player.HasItem("Crystal of Water"))
                        {
                            Console.WriteLine("- Crystal of Water");
                        }

                        if (!Player.HasItem("Crystal of Air"))
                        {
                            Console.WriteLine("- Crystal of Air");
                        }

                        Console.WriteLine("Please find all the crystals to enter.");
                    }
                }
                else
                {
                    location.Explore(Player); // Normal location travel
                }
            }
            else
            {
                Console.WriteLine("Location not found.");
            }
        }
    }
}
