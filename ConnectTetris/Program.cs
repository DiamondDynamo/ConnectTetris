/// <summary>
/// Project Name: Connect Tetris
/// Written by: Charley Bein, Ben Tipton
/// Ver: 1.0
/// Project Summary: Allows two player to play a game of Connect Four in which a line being filled without someone winning causes it to be deleted, preventing draws
/// File Summary: Driver to run the game until a win state is achieved
/// </summary>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace ConnectTetris
{
    class Program
    {
        const string saveFileName = "SaveFile.xml";
        //Driver, which loops until somebody wins the game, at which point, the winner is displayed
        static void Main(string[] args)
        {
            int turn = 0;
            int gameState = 0;
            GameManager game = new GameManager();

            if (File.Exists(saveFileName))
            {
                Console.Write("Would you like to load the saved game? (y/n): ");
                string input = Console.ReadLine();
                if (String.Equals(input, "y", StringComparison.CurrentCultureIgnoreCase))
                {
                    Stream SaveFile = File.OpenRead(saveFileName);
                    SoapFormatter deserializer = new SoapFormatter();
                    SaveGame saved = (SaveGame) deserializer.Deserialize(SaveFile);
                    turn = saved.turnNo;
                    LinkedListNode<Token[]> row = game.rowlist.First;
                    for(int i = 0; i < GameManager.height + 2; i++)
                    {
                        for(int j = 0; j < GameManager.width + 2; j++)
                        {
                            row.Value[j].SetColor(saved.gameBoard[i, j]);
                        }
                        row = row.Next;
                    }
                    SaveFile.Close();
                }
                File.Delete(saveFileName);
            }

            do
            {
                game.ToDraw();
                gameState = IOManager.NewMove(turn, game);
                turn++;
            } while (gameState == 0);
            if(gameState == -1)
            {
                Stream saveFile = File.Create(saveFileName);
                SoapFormatter serializer = new SoapFormatter();
                SaveGame save = new SaveGame();
                save.turnNo = turn + 1;
                int i = 0;
                foreach (Token[] t in game.rowlist)
                {
                    int j = 0;
                    foreach (Token token in t)
                    {
                        save.gameBoard[i, j] = token.GetColor();
                        j++;
                    }
                    i++;
                }
                serializer.Serialize(saveFile, save);
                return;
            }
            game.ToDraw();
            Console.WriteLine("Player {0} wins!", gameState);
            Console.ReadLine();
        }
    }
}
