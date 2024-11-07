using System;
using System.Collections.Generic;
using System.Globalization;

namespace Cool_Flower_Shop
{
    // Item Class
    class Item
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }

        public Item(string itemName, decimal price)
        {
            ItemName = itemName;
            Price = price;
        }
    }

    // Store Class
    class Store
    {
        public string StoreName { get; set; }
        public List<Item> Items { get; set; }

        public Store(string storeName)
        {
            StoreName = storeName;
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void DisplayItems()
        {
            Console.WriteLine($"Welcome to {StoreName}!");
            Console.WriteLine("Flowers available for purchase:");
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Items[i].ItemName} - {Items[i].Price.ToString("C", CultureInfo.CurrentCulture)}");
            }
        }

        public void CalculateTotalCost(Dictionary<Item, int> order)
        {
            decimal totalCost = 0;
            Console.WriteLine("\nOrder Summary:");
            
            foreach (var entry in order)
            {
                var item = entry.Key;      
                int quantity = entry.Value; 
                decimal cost = item.Price * quantity;
                
                Console.WriteLine($"{quantity} x {item.ItemName} - {cost.ToString("C", CultureInfo.CurrentCulture)}");
                
                totalCost += cost; 
            }
            
            Console.WriteLine($"\nTotal is currently {totalCost.ToString("C", CultureInfo.CurrentCulture)}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            // Create store and flower items
            Store store = new Store("Cool Flower Shop");
            Item item1 = new Item("Roses", 19.99m);
            Item item2 = new Item("Tulips", 12.50m);
            Item item3 = new Item("Daisies", 7.25m);
            Item item4 = new Item("Orchids", 25.75m);
            Item item5 = new Item("Sunflowers", 9.99m);

            // Add flowers to the store
            store.AddItem(item1);
            store.AddItem(item2);
            store.AddItem(item3);
            store.AddItem(item4);
            store.AddItem(item5);

            // Display flowers and allow player to order
            Dictionary<Item, int> order = new Dictionary<Item, int>();
            store.DisplayItems();
            
            while (true)
            {
                Console.Write("\nEnter the flower number to purchase (0 to finish): ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice) && choice == 0)
                {
                    break;
                }
                if (choice < 1 || choice > store.Items.Count)
                {
                    Console.WriteLine("Invalid item number, please try again.");
                    continue;
                }
                
                Console.Write($"How many {store.Items[choice - 1].ItemName}s do you want? ");
                int quantity;
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                {
                    if (order.ContainsKey(store.Items[choice - 1]))
                    {
                        order[store.Items[choice - 1]] += quantity;
                    }
                    else
                    {
                        order.Add(store.Items[choice - 1], quantity);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive quantity.");
                }
            }

            // Calculate total cost and display order summary
            if (order.Count > 0)
            {
                store.CalculateTotalCost(order);
            }
            else
            {
                Console.WriteLine("No items ordered.");
            }
        }
    }
}