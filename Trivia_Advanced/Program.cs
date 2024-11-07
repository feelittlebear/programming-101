/*
PROG 101
By Phi Nguyen
Fall 2024
*/

using System;
using System.Linq;

namespace Trivia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set title and display
            Console.Title = "Trivia Game by Phi Nguyen";
            Console.WriteLine("Welcome to the Trivia Game by Phi Nguyen!\n");

            // Initialize player
            Console.Write("Enter your name: ");
            string? playerName = Console.ReadLine();
            Player player = new Player(playerName!);

            // Create a list of trivia questions
            TriviaItem[] triviaItems = new TriviaItem[]
            {
                new TriviaItem("What city has the largest population in the world?", "Tokyo, Japan"),
                new TriviaItem("What city has the most diversity in the world", "Toronto, Canada"),
                new TriviaItem("What is the weathiest city in the world?", "New York City")
            };

            // Randomize multiple choice options for each trivia question
            Random rand = new Random();
            foreach (var trivia in triviaItems)
            {
                // Create a list of all possible wrong answers from other questions
                string[] wrongAnswers = triviaItems
                                        .Where(t => t != trivia)
                                        .Select(t => t.CorrectAnswer)
                                        .OrderBy(_ => rand.Next()) // Randomize wrong answers
                                        .Take(2)
                                        .ToArray();

                // Add the correct answer and randomize all three options
                string[] options = wrongAnswers.Concat(new string[] { trivia.CorrectAnswer })
                                               .OrderBy(_ => rand.Next())
                                               .ToArray();
                trivia.SetOptions(options);
            }

            // Game loop for each trivia question
            foreach (var trivia in triviaItems)
            {
                // Display the question and options
                Console.WriteLine(trivia.Question);
                for (int i = 0; i < trivia.Options!.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {trivia.Options[i]}");
                }

                // Get player's answer
                Console.Write("Enter the number of your choice: ");
                int playerChoice;
                while (!int.TryParse(Console.ReadLine(), out playerChoice) || playerChoice < 1 || playerChoice > 3)
                {
                    Console.WriteLine("Invalid input. Please choose a number between 1 and 3.");
                }

                // Check if the answer is correct
                if (trivia.Options[playerChoice - 1] == trivia.CorrectAnswer)
                {
                    Console.WriteLine("Correct!\n");
                    player.UpdateScore(true);
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is: {trivia.CorrectAnswer}\n");
                    player.UpdateScore(false);
                }

                // Display current score
                player.DisplayScore();
                Console.WriteLine(); // blank line for readability
            }

            // Show final score
            Console.WriteLine($"Game Over! {player.Name}'s final score is: {player.Score}");
        }
    }
}

