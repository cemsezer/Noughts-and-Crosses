using System;
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

        public List<CellStatus> MakeNextMove(CellStatus cellStatus, int cellIndex)
        {
            _board[cellIndex] = cellStatus;
            return _board;
        }

        public int GetNextRandomAvailableCellIndex()
        {
            var availableCells = new List<int>();
            
            for (var i = 0; i < _board.Count; i++)
            {
                if(_board[i] == CellStatus.Empty)
                    availableCells.Add(i);
            }

            var next = new Random().Next(0, availableCells.Count-1);
            return availableCells[next];
        }
    }
}