using System.Collections.Generic;

namespace NoughtsAndCrosses.Console
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Game
    {
        public List<string> InitializeBoard()
        {
            var board = new List<string>();

            for (var i = 0; i < 9; i++)
            {
                board.Add(string.Empty);
            }

            return board;
        }
    }
}
