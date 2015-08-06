using System.Collections.Generic;

namespace NoughtsAndCrosses
{
    /// <summary>
    /// Holds the current status of all cells in the game board
    /// </summary>
    public class Board
    {
        public Board()
        {
            Cells = new List<Cell>();
            
            for (var i = 0; i < 9; i++)
            {
               Cells.Add(new Cell());
            }   
        }

        public List<Cell> Cells { get; set; }
    }
}