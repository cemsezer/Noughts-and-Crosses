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
            var board = game.InitializeBoard();

            //Assert
            Assert.AreEqual(9, board.Count);

            foreach (var cell in board)
            {
                Assert.AreEqual(Game.CellStatus.Empty, cell);
            }
        }

        [TestMethod]
        public void GivenGameInitializes_WhenPlayer1MakesAMove_ThenBoardShouldShowThis()
        {
            // Assign
            var game = new Game();
            var board = game.InitializeBoard();
            var randomCell = new Random().Next(0, 8);

            // Act
            board = game.MakeNextMove(Game.CellStatus.Player1, randomCell);

            // Assert
            for (var i = 0; i < board.Count; i++)
            {
                if (i == randomCell)
                {
                    Assert.AreEqual(Game.CellStatus.Player1, board[randomCell]);
                    continue;
                }

                Assert.AreEqual(Game.CellStatus.Empty, board[i]);
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
            game.MakeNextMove(Game.CellStatus.Player1, player1CellIndex);

            var player2Cell = game.GetNextRandomAvailableCellIndex();
            game.MakeNextMove(Game.CellStatus.Player2, player2Cell);

            // Assert
            Assert.AreNotEqual(player1CellIndex, player2Cell);
        }
    }
}