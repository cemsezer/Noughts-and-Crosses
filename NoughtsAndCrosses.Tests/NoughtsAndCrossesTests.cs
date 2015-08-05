using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoughtsAndCrosses.Console;

namespace NoughtsAndCrosses.Tests
{
    [TestClass]
    public class NoughtsAndCrossesTests
    {
        [TestMethod]
        public void GivenGameInitialises_WhenGameStarts_ShouldHaveEmptyBoard()
        {
            // Assign
            var game = new Game();

            // Act
            var board = game.InitializeBoard();

            //Assert
            Assert.AreEqual(9, board.Count);
            
            foreach (var cell in board)
            {
                Assert.AreEqual(string.Empty, cell);
            }
        }
    }
}
