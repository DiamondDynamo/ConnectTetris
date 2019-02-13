///<summary>
///Class of static methods to take input and display output
/// (General info in Program.cs)
/// </summary>
using System;

namespace ConnectTetris
{
    class IOManager
    {
        // Draw the given array to the console
        public static void Draw(int[,] grid)
        {
            Console.Clear();
            for(int i = 1; i <= GameManager.width; i++)
            {
                Console.Write("| {0} ", i);
            }
            Console.WriteLine("|");
            Console.WriteLine(" ----------------------------");
            for(int i = GameManager.height ; i > 0; i--)
            {
                for(int j = 1; j < GameManager.width + 1; j++)
                {
                    Console.Write("| {0} ", grid[i, j]);
                }
                Console.Write("|\n");
            }
        }

        // Take user input to get the position, and pass it to the game manager
        public static int NewMove(int turnNo, GameManager game)
        {
            int player = turnNo % 2 + 1;
            Console.Write("Player {0}, make your move ", player);
            string playString = Console.ReadLine();
            int play = Int32.Parse(playString);
            return game.AddToken(play, player);
        }
    }
}
