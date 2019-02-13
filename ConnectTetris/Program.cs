/// <summary>
/// Project Name: Connect Tetris
/// Written by: Charley Bein, Ben Tipton
/// Ver: 1.0
/// Summary: Allows two player to play a game of Connect Four in which a line being filled without someone winning causes it to be deleted, preventing draws
/// </summary>

using System;

namespace ConnectTetris
{
    class Program
    {
        //Driver, which loops until somebody wins the game, at which point, the winner is displayed
        static void Main(string[] args)
        {
            int turn = 0;
            int gameState = 0;
            GameManager game = new GameManager();
            do
            {
                game.ToDraw();
                gameState = IOManager.NewMove(turn, game);
                turn++;
            } while (gameState == 0);
            game.ToDraw();
            Console.WriteLine("Player {0} wins!", gameState);
            Console.ReadLine();
        }
    }
}
