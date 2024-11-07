/*
PROG 101 Midterm Adventure Game
Phi Nguyen
October 23, 2024
*/

using System;

namespace TextBasedAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "You Better Get That Sword Game";
            Game game = new Game();
            game.Start();
        }
    }
}
