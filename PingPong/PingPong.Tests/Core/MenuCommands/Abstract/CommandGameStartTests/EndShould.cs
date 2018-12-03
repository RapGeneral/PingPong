using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.Contracts;
using PingPong.Providers.Contracts;
using PingPong.Tests.Core.MenuCommands.Abstract.Mocks;

namespace PingPong.Tests.Core.MenuCommands.Abstract.CommandGameStartTests
{
	[TestClass]
	public class EndShould
	{
		[DataTestMethod]
		[DataRow(true)]
		[DataRow(false)]
		public void CallDisplayWriteLine_WhenInvoked(bool winner)
		{
			//Arrange
			var mediumFontMock = new Mock<IMediumFont>();
			var bigWordsMock = new Mock<IBigWords>();
			bigWordsMock.Setup(b => b.MakeItBig(
										It.IsAny<string>(), 
										It.IsAny<IMediumFont>(), 
										It.IsAny<int>()))
						.Returns(new string[] { "da", "da" });

			var displayMock = new Mock<IDisplay>();
			displayMock.SetupGet(d => d.WindowWidth).Returns(100);
			displayMock.SetupGet(d => d.WindowHeight).Returns(100);

			var keyReaderMock = new Mock<IKeyReader>();
			//Act
			new CommandGameStartMock(
				mediumFontMock.Object, 
				bigWordsMock.Object, 
				displayMock.Object, 
				keyReaderMock.Object)
			.EndMock(winner);
			//Assert
			displayMock.Verify(d => d.WriteLine(It.IsAny<string>()), Times.AtLeastOnce);
		}
		
	}
}
