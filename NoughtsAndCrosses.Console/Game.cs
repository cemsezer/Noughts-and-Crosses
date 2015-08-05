using System;
using System.Collections.Generic;

namespace NoughtsAndCrosses.Console
{
    public class Game
    {
        public Board Board { get; private set; }

        public void InitializeBoard()
        {
            Board = new Board();
        }

        public void MakeNextMove(Cell cell, int cellIndex)
        {
            Board.Cells[cellIndex] = cell;
        }

        public int GetNextRandomAvailableCellIndex()
        {
            var availableCells = new List<int>();

            for (var i = 0; i < Board.Cells.Count; i++)
            {
                if (Board.Cells[i] == Cell.Empty)
                    availableCells.Add(i);
            }

            var next = new Random().Next(0, availableCells.Count - 1);
            return availableCells[next];
        }
    }
}