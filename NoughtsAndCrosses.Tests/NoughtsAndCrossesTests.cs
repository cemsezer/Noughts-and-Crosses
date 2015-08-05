using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoughtsAndCrosses.Console;

namespace NoughtsAndCrosses.Tests
{
    [TestClass]
    public class NoughtsAndCrossesTests
    {
        [TestMethod]
        public void GivenGameInitializes_WhenGameStarts_ShouldHaveEmptyBoard()
        {
            // Assign
            var game = new Game();

            // Act
            game.InitializeBoard();

            //Assert
            Assert.AreEqual(9, game.Board.Cells.Count);

            foreach (var cell in game.Board.Cells)
            {
                Assert.AreEqual(Cell.Empty, cell);
            }
        }

        [TestMethod]
        public void GivenGameInitializes_WhenPlayer1MakesAMove_ThenBoardShouldShowThis()
        {
            // Assign
            var game = new Game();
            game.InitializeBoard();
            var randomCell = new Random().Next(0, 8);

            // Act
            game.MakeNextMove(Cell.Player1, randomCell);

            // Assert
            for (var i = 0; i < game.Board.Cells.Count; i++)
            {
                if (i == randomCell)
                {
                    Assert.AreEqual(Cell.Player1, game.Board.Cells[randomCell]);
                    continue;
                }

                Assert.AreEqual(Cell.Empty, game.Board.Cells[i]);
            }
        }

        [TestMethod]
        public void GivenGameInitializes_WhenGameStarts_PlayersShouldPickRandomCells()
        {
            // Assign
            var game = new Game();
            game.InitializeBoard();

            // Act
            var player1CellIndex = game.GetNextRandomAvailableCellIndex();
            game.MakeNextMove(Cell.Player1, player1CellIndex);

            var player2Cell = game.GetNextRandomAvailableCellIndex();
            game.MakeNextMove(Cell.Player2, player2Cell);

            // Assert
            Assert.AreNotEqual(player1CellIndex, player2Cell);
        }
    }
}