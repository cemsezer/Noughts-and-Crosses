using System;

namespace NoughtsAndCrosses
{
    /// <summary>
    /// Main entry point for the Noughts And Crosses
    /// Prompts user to start the game and repeats the game until user closes the console window
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new BoardDisplayer());

            while (true)
            {
                Console.WriteLine("Press any key to start");
                Console.ReadKey();

                game.InitializeBoard();

                while (true)
                {
                    if (game.PlayAndCheck(Player.Player1, game.GetNextRandomAvailableCellIndex()))
                        break;

                    if (game.PlayAndCheck(Player.Player2, game.GetNextRandomAvailableCellIndex()))
                        break;
                }
            }
        }
    }
}