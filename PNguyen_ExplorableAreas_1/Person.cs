using System;
using System.Collections.Generic;

namespace MysticRealmsAdventure
{
    // Person class representing player and NPCs
    class Person
    {
        public string Name { get; set; }
        public List<Item> Inventory { get; set; }

        public Person(string name)
        {
            Name = name;
            Inventory = new List<Item>();
        }

        public void Talk()
        {
            Console.WriteLine($"{Name} says: Greetings, traveler.");
        }

        public void AddToInventory(Item item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{item.Name} has been added to your inventory.");
        }

        public bool HasItem(string itemName)
        {
            foreach (Item item in Inventory)
            {
                if (item.Name == itemName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
