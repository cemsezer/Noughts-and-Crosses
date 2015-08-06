using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NoughtsAndCrosses.Tests
{
    [TestClass]
    public class NoughtsAndCrossesTests
    {
        [TestMethod]
        public void GivenGameInitializes_WhenGameStarts_ThenShouldHaveEmptyBoard()
        {
            // Assign
            var game = new Game(new BoardDisplayer());

            // Act
            game.InitializeBoard();

            // Assert
            Assert.AreEqual(9, game.Board.Cells.Count);

            foreach (var cell in game.Board.Cells)
            {
                Assert.IsFalse(cell.Value.HasValue);
            }
        }

        [TestMethod]
        public void GivenGameInitializes_WhenPlayer1MakesAMove_ThenBoardShouldShowThis()
        {
            // Assign
            var game = new Game(new BoardDisplayer());
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

                Assert.IsFalse(game.Board.Cells[i].Value.HasValue);
            }
        }

        [TestMethod]
        public void GivenGameInitializes_WhenGameStarts_ThenPlayersShouldPickRandomCells()
        {
            // Assign
            var game = new Game(new BoardDisplayer());
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
            var game = new Game(new BoardDisplayer());
            game.InitializeBoard();
            game.MakeNextMove(Player.Player1, 0);
            game.MakeNextMove(Player.Player1, 1);
            game.MakeNextMove(Player.Player1, 2);

            // Act
            var hasPlayerWon = game.HasPlayerWon(Player.Player1);

            // Assert
            Assert.IsTrue(hasPlayerWon);
        }

        [TestMethod]
        public void GivenGameInitializes_WhenAPlayerDoesNotTicksWinningCombination_ThenPlayer1ShouldNotWin()
        {
            // Assign
            var game = new Game(new BoardDisplayer());
            game.InitializeBoard();
            game.MakeNextMove(Player.Player1, 0);
            game.MakeNextMove(Player.Player1, 1);
            game.MakeNextMove(Player.Player1, 3);

            // Act
            var hasPlayerWon = game.HasPlayerWon(Player.Player1);

            // Assert
            Assert.IsFalse(hasPlayerWon);
        }

        [TestMethod]
        public void GivenGameInitializes_WhenPlayersNotUseAllTheCells_ThenGameShouldNotFinish()
        {
            // Assign
            var game = new Game(new BoardDisplayer());
            game.InitializeBoard();

            for (var i = 0; i < game.Board.Cells.Count - 1; i++)
            {
                game.MakeNextMove(Player.Player1, i);
            }

            // Act
            bool isFinished = game.IsGameFinished();

            // Assert
            Assert.IsFalse(isFinished);
        }

        [TestMethod]
        public void GivenGameInitializes_WhenPlayersUseAllTheCells_ThenGameShouldFinish()
        {
            // Assign
            var game = new Game(new BoardDisplayer());
            game.InitializeBoard();

            for (var i = 0; i < game.Board.Cells.Count; i++)
            {
                game.MakeNextMove(Player.Player1, i);
            }

            // Act
            bool isFinished = game.IsGameFinished();

            // Assert
            Assert.IsTrue(isFinished);
        }

        [TestMethod]
        public void GivenGameInitializes_WhenAPlayerPlays_ThenShouldDisplayBoard()
        {
            // Assign
            var boardDisplayerMock = new Mock<IBoardDisplayer>();
            var game = new Game(boardDisplayerMock.Object);
            game.InitializeBoard();

            // Act
            game.PlayAndCheck(Player.Player1);

            //Assert
            boardDisplayerMock.Verify(b => b.DisplayBoard(game.Board), Times.Once);

        }

        [TestMethod]
        public void GivenGameInitializes_WhenAPlayerWins_ThenShouldDisplayResult()
        {
            // Assign
            var boardDisplayerMock = new Mock<IBoardDisplayer>();
            var game = new Game(boardDisplayerMock.Object);
            game.InitializeBoard();
            game.MakeNextMove(Player.Player1, 0);
            game.MakeNextMove(Player.Player1, 1);
            game.MakeNextMove(Player.Player1, 2);

            // Act
            game.PlayAndCheck(Player.Player1);

            // Assert
            boardDisplayerMock.Verify(b => b.DisplayWinner(Player.Player1));
        }

        [TestMethod]
        public void GivenGameInitializes_WhenAPlayerNotWins_ThenShouldNotDisplayResult()
        {
            // Assign
            var boardDisplayerMock = new Mock<IBoardDisplayer>();
            var game = new Game(boardDisplayerMock.Object);
            game.InitializeBoard();
            game.MakeNextMove(Player.Player1, 0);

            // Act
            game.PlayAndCheck(Player.Player1);

            // Assert
            boardDisplayerMock.Verify(b => b.DisplayWinner(Player.Player1), Times.Never);
        }

        [TestMethod]
        public void GivenGameInitializes_WhenAPlayerPlays_ThenShouldCheckIfGameIsOver()
        {
            // Assign
            var boardDisplayerMock = new Mock<IBoardDisplayer>();
            var game = new Game(boardDisplayerMock.Object);
            game.InitializeBoard();
            
            // Act
            var isOver = game.PlayAndCheck(Player.Player1);

            // Assert
            Assert.IsFalse(isOver);
        }
    }
}