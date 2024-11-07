using System;
using System.Collections.Generic;

namespace TextBasedAdventureGame
{
    public class Game
    {
        private Player player;
        private List<Enemy> enemies;

        public Game()
        {
            player = new Player();
            enemies = new List<Enemy>();
            InitializeEnemies();
        }

        public void Start()
        {
            // Set console background color and default text color
            Console.BackgroundColor = ConsoleColor.Black; // Set background color to black
            Console.ForegroundColor = ConsoleColor.White; // Set default text color to white
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
            
▗▖  ▗▖▗▄▖ ▗▖ ▗▖    ▗▄▄▖ ▗▄▄▄▖▗▄▄▄▖▗▄▄▄▖▗▄▄▄▖▗▄▄▖      ▗▄▄▖▗▄▄▄▖▗▄▄▄▖    ▗▄▄▄▖▗▖ ▗▖ ▗▄▖▗▄▄▄▖     ▗▄▄▖▗▖ ▗▖ ▗▄▖ ▗▄▄▖ ▗▄▄▄  
 ▝▚▞▘▐▌ ▐▌▐▌ ▐▌    ▐▌ ▐▌▐▌     █    █  ▐▌   ▐▌ ▐▌    ▐▌   ▐▌     █        █  ▐▌ ▐▌▐▌ ▐▌ █      ▐▌   ▐▌ ▐▌▐▌ ▐▌▐▌ ▐▌▐▌  █ 
  ▐▌ ▐▌ ▐▌▐▌ ▐▌    ▐▛▀▚▖▐▛▀▀▘  █    █  ▐▛▀▀▘▐▛▀▚▖    ▐▌▝▜▌▐▛▀▀▘  █        █  ▐▛▀▜▌▐▛▀▜▌ █       ▝▀▚▖▐▌ ▐▌▐▌ ▐▌▐▛▀▚▖▐▌  █ 
  ▐▌ ▝▚▄▞▘▝▚▄▞▘    ▐▙▄▞▘▐▙▄▄▖  █    █  ▐▙▄▄▖▐▌ ▐▌    ▝▚▄▞▘▐▙▄▄▖  █        █  ▐▌ ▐▌▐▌ ▐▌ █      ▗▄▄▞▘▐▙█▟▌▝▚▄▞▘▐▌ ▐▌▐▙▄▄▀ 
                                                                                                                         
                                                                                                                         
                                                                                                                                                                                                                          
                                                                                                                          
");
            Console.ForegroundColor = ConsoleColor.White;
            // Introduction to the game
            Console.WriteLine("Welcome, brave adventurer! You are the chosen one from your village, destined to explore the mysterious ruins and find the ancient magical sword.");
            Console.WriteLine("Your journey begins now...");

            Console.Write("Before you begin, please enter your name: ");
            player.Name = Console.ReadLine()!;

            Console.WriteLine($"\nGreetings, {player.Name}! You begin your journey with 100 health.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("For each riddle you come across, remember to not answer with 'a' or 'an'. For example: answer 'flower' instead of 'a flower'.");
            ExploreRuins();
        }

        private void InitializeEnemies()
        {
            enemies.Add(new Enemy("Whispering Wisp", new Riddle("I speak without a mouth and hear without ears. What am I?", "echo")));
            enemies.Add(new Enemy("Flame Spirit", new Riddle("I am not alive, but I can grow. I do not have lungs, but I need air. What am I?", "fire", "flame")));
            enemies.Add(new Enemy("Mischievous Jester", new Riddle("I can be cracked, made, told, and played. What am I?", "joke")));
        }

        private void ExploreRuins()
        {
            ChamberOne();
            ChamberTwo();
            ChamberThree();
            FindSword();
            EncounterEnemies();
        }

        private void ChamberOne()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nYou enter Chamber 1. The air is thick with the scent of damp earth, and flickering shadows dance along the walls.");
            Console.WriteLine("A voice echoes in the darkness: 'To proceed, answer my riddle.'");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Riddle: I have keys but open no locks. I have space but no room. You can enter, but you can't go outside. What am I?");
            var riddle = new Riddle("I have keys but open no locks. I have space but no room. You can enter, but you can't go outside.", "keyboard");

            if (!AskRiddle(riddle))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect! The door remains locked. You must answer correctly to continue.");
                ChamberOne();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct! The door creaks open, allowing you to proceed.");
            }
        }

        private void ChamberTwo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nYou step into Chamber 2. The walls are adorned with glowing runes, and a soft hum resonates through the air.");
            Console.WriteLine("Another voice calls out: 'To pass, you must solve my riddle.'");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Riddle: I can fly without wings. I can cry without eyes. Wherever I go, darkness flies. What am I?");
            var riddle = new Riddle("I can fly without wings. I can cry without eyes. Wherever I go, darkness flies. What am I?", "cloud", "raincloud", "stormcloud", "rain cloud", "storm cloud");

            if (!AskRiddle(riddle))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect! The way is blocked. You must solve the riddle to move forward.");
                ChamberTwo();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Well done! The glowing runes part, revealing the path ahead.");
            }
        }

        private void ChamberThree()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nYou arrive in Chamber 3. A gentle breeze carries whispers of ancient secrets, and the air feels charged with magic.");
            Console.WriteLine("A deep voice resounds: 'Answer my riddle to unlock the path.'");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Riddle: I am taken from a mine, and shut up in a wooden case, from which I am never released. What am I?");
            var riddle = new Riddle("I am taken from a mine, and shut up in a wooden case, from which I am never released. What am I?", "pencil lead", "graphite", "lead");

            if (!AskRiddle(riddle))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect! The entrance remains sealed. You must answer correctly to proceed.");
                ChamberThree();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You are wise! The way forward opens before you.");
            }
        }

        private void FindSword()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nFinally, you enter the sacred chamber where the ancient sword rests on a pedestal, radiating power.");
            Console.WriteLine("You have found the magical sword! Your strength increases, and now you can face the shadows that lurk in the ruins.");
        }

        private void EncounterEnemies()
        {
            foreach (var enemy in enemies)
            {
                EncounterEnemy(enemy);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
            
 ▗▄▄▖▗▄▄▖ ▗▖   ▗▄▄▄▖▗▖  ▗▖▗▄▄▄  ▗▄▄▄▖▗▄▄▄  
▐▌   ▐▌ ▐▌▐▌   ▐▌   ▐▛▚▖▐▌▐▌  █   █  ▐▌  █ 
 ▝▀▚▖▐▛▀▘ ▐▌   ▐▛▀▀▘▐▌ ▝▜▌▐▌  █   █  ▐▌  █ 
▗▄▄▞▘▐▌   ▐▙▄▄▖▐▙▄▄▖▐▌  ▐▌▐▙▄▄▀ ▗▄█▄▖▐▙▄▄▀                                                                                                                                                      
");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou have successfully exited the ruins and return to your village. Your journey ends here.");
        }
        

        private void EncounterEnemy(Enemy enemy)
        {
            List<string> encounterDescriptions = new List<string>
            {
                "As you near the exit, a shadow flits across your path.",
                "Just ahead, a flicker of movement catches your eye as you approach freedom.",
                "The air grows colder as you sense another presence lurking close to the exit."
            };

            Random random = new Random();
            int index = random.Next(encounterDescriptions.Count);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(encounterDescriptions[index]);

            Console.WriteLine($"\nYou encounter {enemy.Name}!");

            bool defeated = false;
            while (!defeated)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("To defeat this foe, you must answer their riddle correctly.");
                Console.WriteLine($"Riddle: {enemy.Riddle.Question}");
                string? playerAnswer = Console.ReadLine();

                if (enemy.Riddle.CheckAnswer(playerAnswer!))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! You have defeated the enemy!");
                    defeated = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect! You have lost health.");
                    player.TakeDamage(10);

                    if (player.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have fallen in battle. Game over.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine($"You have {player.Health} health remaining. Try again!");
                    }
                }
            }
        }

        private bool AskRiddle(Riddle riddle)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            string? playerAnswer = Console.ReadLine();
            return riddle.CheckAnswer(playerAnswer!);
        }
    }
}
