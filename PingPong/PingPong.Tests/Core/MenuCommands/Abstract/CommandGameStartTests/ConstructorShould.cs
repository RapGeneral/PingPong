using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.Contracts;
using PingPong.Core.MenuCommands.Abstract;
using PingPong.Providers.Contracts;
using PingPong.Tests.Core.MenuCommands.Abstract.Mocks;
using System;

namespace PingPong.Tests.Core.MenuCommands.Abstract.CommandGameStartTests
{
	[TestClass]
	public class ConstructorShould
	{
		[TestMethod]
		public void ThrowNullException_WhenMediumFontIsNull()
		{
			//Arrange
			var bigWordsMock = new Mock<IBigWords>();
			var displayMock = new Mock<IDisplay>();
			var keyReaderMock = new Mock<IKeyReader>();
			//Act & Assert
			Assert.ThrowsException<ArgumentNullException>(
				() => new CommandGameStartMock(null, 
											   bigWordsMock.Object, 
											   displayMock.Object, 
											   keyReaderMock.Object));
		}

		[TestMethod]
		public void ThrowNullException_WhenBigWordsIsNull()
		{
			//Arrange
			var mediumFontMock = new Mock<IMediumFont>();
			var displayMock = new Mock<IDisplay>();
			var keyReaderMock = new Mock<IKeyReader>();
			//Act & Assert
			Assert.ThrowsException<ArgumentNullException>(
				() => new CommandGameStartMock(mediumFontMock.Object,
											   null,
											   displayMock.Object,
											   keyReaderMock.Object));
		}

		[TestMethod]
		public void ThrowNullException_WhenDisplayIsNull()
		{
			//Arrange
			var mediumFontMock = new Mock<IMediumFont>();
			var bigWordsMock = new Mock<IBigWords>();
			var keyReaderMock = new Mock<IKeyReader>();
			//Act & Assert
			Assert.ThrowsException<ArgumentNullException>(
				() => new CommandGameStartMock(mediumFontMock.Object,
											   bigWordsMock.Object,
											   null,
											   keyReaderMock.Object));
		}

		[TestMethod]
		public void ThrowNullException_WhenKeyReaderIsNull()
		{
			//Arrange
			var mediumFontMock = new Mock<IMediumFont>();
			var bigWordsMock = new Mock<IBigWords>();
			var displayMock = new Mock<IDisplay>();
			//Act & Assert
			Assert.ThrowsException<ArgumentNullException>(
				() => new CommandGameStartMock(mediumFontMock.Object,
											   bigWordsMock.Object,
											   displayMock.Object,
											   null));
		}
	}
}
