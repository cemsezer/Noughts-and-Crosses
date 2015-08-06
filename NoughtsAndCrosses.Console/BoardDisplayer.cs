using System;
using System.Threading;

namespace NoughtsAndCrosses
{
    /// <summary>
    /// Responsible of displaying the current status of the game board on Console
    /// </summary>
    public class BoardDisplayer : IBoardDisplayer
    {
        public void DisplayBoard(Board board)
        {
            Console.Clear();
            Console.WriteLine("Player1: X");
            Console.WriteLine("Player2: O");
            Console.WriteLine("");
            Console.WriteLine("|{0}{1}{2}|", ConvertToSign(board.Cells[0].Value), ConvertToSign(board.Cells[1].Value), ConvertToSign(board.Cells[2].Value));
            Console.WriteLine("|{0}{1}{2}|", ConvertToSign(board.Cells[3].Value), ConvertToSign(board.Cells[4].Value), ConvertToSign(board.Cells[5].Value));
            Console.WriteLine("|{0}{1}{2}|", ConvertToSign(board.Cells[6].Value), ConvertToSign(board.Cells[7].Value), ConvertToSign(board.Cells[8].Value));

            Thread.Sleep(1000);
        }

        public void DisplayWinner(Player player)
        {
            Console.WriteLine("{0} wins", player);
        }

        public void DisplayNoWinner()
        {
            Console.WriteLine("No winner");
        }

        private static string ConvertToSign(Player? cellValue)
        {
            switch (cellValue)
            {
                case null:
                    return " ";
                case Player.Player1:
                    return "X";
                case Player.Player2:
                    return "O";
            }

            throw new NotImplementedException();
        }
    }
}