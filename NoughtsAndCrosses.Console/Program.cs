using System.Collections.Generic;

namespace NoughtsAndCrosses.Console
{
    public class Game
    {
        private List<CellStatus> _board;
        public enum CellStatus {Empty, Player1, Player2 }

        public List<CellStatus> InitializeBoard()
        {
            _board = new List<CellStatus>();

            for (var i = 0; i < 9; i++)
            {
                _board.Add(CellStatus.Empty);
            }

            return _board;
        }

        public List<CellStatus> MakeMove(CellStatus cellStatus, int cellIndex)
        {
            _board[cellIndex] = cellStatus;
            return _board;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}