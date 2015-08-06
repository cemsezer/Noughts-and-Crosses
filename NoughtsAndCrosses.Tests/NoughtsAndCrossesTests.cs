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
                Assert.IsNull(cell.Value);
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
            game.MakeNextMove(Player.Player1, randomCell);

            // Assert
            for (var i = 0; i < game.Board.Cells.Count; i++)
            {
                if (i == randomCell)
                {
                    Assert.AreEqual(Player.Player1, game.Board.Cells[randomCell].Value);
                    continue;
                }

                Assert.IsNull(game.Board.Cells[i].Value);
            }
        }

        [TestMethod]
        public void GivenGameInitializes_WhenGameStarts_ThenPlayersShouldPickRandomCells()
        {
            // Assign
            var game = new Game();
            game.InitializeBoard();

            // Act
            var player1CellIndex = game.GetNextRandomAvailableCellIndex();
            game.MakeNextMove(Player.Player1, player1CellIndex);

            var player2Cell = game.GetNextRandomAvailableCellIndex();
            game.MakeNextMove(Player.Player2, player2Cell);

            // Assert
            Assert.AreNotEqual(player1CellIndex, player2Cell);
        }

        [TestMethod]
        public void GivenGameInitializes_WhenAPlayerTicksWinningCombination_ThenPlayer1ShouldWin()
        {
            // Assign
            var game = new Game();
            game.InitializeBoard();
            game.MakeNextMove(Player.Player1, 0);
            game.MakeNextMove(Player.Player1, 1);
            game.MakeNextMove(Player.Player1, 2);

            // Act
            var hasPlayerWon = game.HasPlayerWon(Player.Player1);

            // Assert
            Assert.IsTrue(hasPlayerWon);
        }
    }
}