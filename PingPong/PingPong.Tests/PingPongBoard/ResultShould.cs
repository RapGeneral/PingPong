using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Board;
using PingPong.Board.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.Tests.PingPongBoard
{
    [TestClass]
    public class ResultShould
    {
        [TestMethod]
        public void IncreaseLeft_ShouldWorkCorrect()
        {
            var gameBoard = new GameBoard(10,10);
            var result = new Result(gameBoard, 0, 0);
            result.IncreaseLeft();

            Assert.AreEqual(result.LeftResult, 1);
        }
        [TestMethod]
        public void IncreaseRight_ShouldWorkCorrect()
        {
            var gameBoard = new GameBoard(10, 10);
            var result = new Result(gameBoard, 0, 0);
            result.IncreaseRight();

            Assert.AreEqual(result.RightResult, 1);
        }
    }
}
