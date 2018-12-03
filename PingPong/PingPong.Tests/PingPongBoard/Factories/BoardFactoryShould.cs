using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Board.Factories;
using PingPong.Board;
using Moq;
using PingPong.Board.Contracts;

namespace PingPong.Tests.PingPongBoard.Factories
{
    [TestClass]
    public class BoardFactoryShould
    {
        [TestMethod]
        public void CreateBallShould_CreateBall()
        {
            var factory = new BoardFactory();
            var gameBoard = new GameBoard(10, 10);

            var ball = factory.CreateBall(gameBoard);

            Assert.IsInstanceOfType(ball, typeof(Ball));
        }
        [TestMethod]
        public void CreateBoardShould_CreateBoard()
        {
            var factory = new BoardFactory();

            var gameBoard = factory.CreateBoard(10, 10);

            Assert.IsInstanceOfType(gameBoard, typeof(GameBoard));
        }
        [TestMethod]
        public void CreateResultShould_CreateResult()
        {
            var factory = new BoardFactory();
            var gameBoard = new GameBoard(10, 10);

            var result = factory.CreateResult(gameBoard);

            Assert.IsInstanceOfType(result, typeof(Result));
        }

        [TestMethod]
        public void CreatePlayerName_ShouldCreateName()
        {
            var factory = new BoardFactory();
            var gameBoard = new GameBoard(10, 10);

            var playerName = factory.CreatePlayerName("Valid name", true, gameBoard);

            Assert.IsInstanceOfType(playerName, typeof(PlayerName));
        }

        [TestMethod]
        public void CreatePlayerLine_ShouldCreateLine()
        {
            var factory = new BoardFactory();
            var gameBoard = new GameBoard(10, 10);

            var playerLine = factory.CreatePlayerLine(gameBoard, true, 5);

            Assert.IsInstanceOfType(playerLine, typeof(PlayerLine));

        }
    }
}
