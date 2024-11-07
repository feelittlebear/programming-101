using System;
using System.Collections.Generic;

namespace MysticRealmsAdventure
{
    // Location class for realms
    class Location
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; }
        public Person Npc { get; set; }

        public Location(string name, List<Item> items, Person npc)
        {
            Name = name;
            Items = items;
            Npc = npc;
        }

        public void Explore(Person player)
        {
            Console.WriteLine($"You are exploring {Name}.");
            Npc.Talk();

            if (Items.Count > 0)
            {
                Console.WriteLine("Items you can find:");

                foreach (Item item in Items)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description}");
                    Console.WriteLine($"Do you want to take {item.Name}? (yes/no)");

                    string? choice = Console.ReadLine();

                    if (choice!.ToLower() == "yes")
                    {
                        player.AddToInventory(item);
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no items to be found here.");
            }
        }
    }
}
