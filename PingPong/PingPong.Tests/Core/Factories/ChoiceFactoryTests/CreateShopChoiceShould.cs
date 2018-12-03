using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.Contracts;
using PingPong.Core.Factories;
using PingPong.Providers.Contracts;
using PingPong.Core.Menus.MenuChoices;

namespace PingPong.Tests.Core.Factories.ChoiceFactoryTests
{
	[TestClass]
	public class CreateShopChoiceShould
	{
		[TestMethod]
		public void ReturnMShopChoice_WhenParametersAreCorrect()
		{
			//Arrange
			var displayMock = new Mock<IDisplay>();
			displayMock.Setup(d => d.WindowHeight).Returns(100);
			displayMock.Setup(d => d.WindowWidth).Returns(100);
			var commandHolderMock = new Mock<ICommandHolder>();
			IChoiceFactory factory = new ChoiceFactory(displayMock.Object);
			//Act
			var actualChoice = factory.CreateaShopChoice(
				10,
				10,
				commandHolderMock.Object);
			//Assert
			Assert.IsInstanceOfType(actualChoice, typeof(ShopChoice));
		}
	}
}
