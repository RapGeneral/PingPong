using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.BigText;
using PingPong.Core.Contracts;
using System;

namespace PingPong.Tests.Core.BigText.BigWordsTests
{
	[TestClass]
	public class MakeItBigShould
	{
		[TestMethod]
		public void ReturnBigText_WhenArgumentsAreCorrectWithSpaces()
		{
			//Arrange
			var fontMock = new Mock<IBigLetters>();
			fontMock.SetupGet(f => f.SpaceInBetween).Returns(1);//Spaces between individual big words
			fontMock.SetupGet(f => f.LetterHeight).Returns(2);//How much layers will the big letters consists of?
			fontMock.Setup(f => f.BigLetterLayer('a', 0)).Returns("aaa");
			fontMock.Setup(f => f.BigLetterLayer('a', 1)).Returns("bbb");
			fontMock.Setup(f => f.BigLetterLayer('x', 0)).Returns("xxx");
			fontMock.Setup(f => f.BigLetterLayer('x', 1)).Returns("yyy");

			IBigWords bigWords = new BigWords();
			string[] expected = new string[]{ "aaa xxx  xxx aaa", "bbb yyy  yyy bbb" };
			//between aaa and xxx is spaceInBetween, between xxx and xxx - the spaces between the words
			//Act
			string[] result = bigWords.MakeItBig("ax xa", fontMock.Object, 2);//the 2 is the space between the big words
			//Assert
			Assert.AreEqual(expected[0], result[0]);
			Assert.AreEqual(expected[1], result[1]);
		}

		[TestMethod]
		public void Throw_WhenWordsIsNull()
		{
			//Arrange
			var fontMock = new Mock<IBigLetters>();
			IBigWords bigWords = new BigWords();
			//Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => bigWords.MakeItBig(null, fontMock.Object, 2));
		}

		[TestMethod]
		public void Throw_WhenFontIsNull()
		{
			//Arrange
			 IBigWords bigWords = new BigWords();
			//Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => bigWords.MakeItBig("smt", null, 2));
		}

		[TestMethod]
		public void Throw_WhenSpaceBetweenWordsIsNegative()
		{
			//Arrange
			var fontMock = new Mock<IBigLetters>();
			IBigWords bigWords = new BigWords();
			//Act & Assert
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => bigWords.MakeItBig("smt", fontMock.Object, -4));
		}

		[TestMethod]
		public void NotThrow_WhenWordsSpaceBetweenWordsIsZero()
		{
			//Arrange
			var fontMock = new Mock<IBigLetters>();
			IBigWords bigWords = new BigWords();
			//Act & Assert
			bigWords.MakeItBig("smt", fontMock.Object, 0);
		}
	}
}
