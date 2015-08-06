using System;
using System.Collections.Generic;
using System.Linq;

namespace NoughtsAndCrosses
{
    /// <summary>
    /// Manages Noughts and Crosses Game, initializes the game board, checks if the game is over
    /// </summary>
    public class Game
    {
        private readonly IBoardDisplayer _boardDisplayer;

        private static readonly List<int[]> WinningCombinations = new List<int[]>
        {
            new[] {0, 1, 2},
            new[] {3, 4, 5},
            new[] {6, 7, 8},
            new[] {0, 3, 6},
            new[] {1, 4, 7},
            new[] {2, 5, 8},
            new[] {0, 4, 8},
            new[] {2, 4, 6},
        };

        public Game(IBoardDisplayer boardDisplayer)
        {
            _boardDisplayer = boardDisplayer;
        }

        public Board Board { get; private set; }

        public void InitializeBoard()
        {
            Board = new Board();
        }

        public void MakeNextMove(Player player, int cellIndex)
        {
            Board.Cells[cellIndex].Value = player;
        }

        public int GetNextRandomAvailableCellIndex()
        {
            var availableCells = new List<int>();

            for (var i = 0; i < Board.Cells.Count; i++)
            {
                if (!Board.Cells[i].HasValue)
                    availableCells.Add(i);
            }

            var next = new Random().Next(0, availableCells.Count - 1);
            return availableCells[next];
        }

        public bool HasPlayerWon(Player player)
        {
            foreach (var winningCombination in WinningCombinations)
            {
                if (Board.Cells[winningCombination[0]].Value == player &&
                    Board.Cells[winningCombination[1]].Value == player &&
                    Board.Cells[winningCombination[2]].Value == player)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsGameFinished()
        {
            var isGameFinished = Board.Cells.All(cell => cell.HasValue);
            if (isGameFinished)
                _boardDisplayer.DisplayNoWinner();
            return isGameFinished;
        }

        /// <summary>
        /// Makes a random move for a player and then checks if the player wins or checks if all cells in the game board were used
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True when game is over</returns>
        public bool PlayAndCheck(Player player)
        {
            MakeNextMove(player, GetNextRandomAvailableCellIndex());
            _boardDisplayer.DisplayBoard(Board);

            if (HasPlayerWon(player))
            {
                _boardDisplayer.DisplayWinner(player);
                return true;
            }

            return IsGameFinished();
        }
    }
}