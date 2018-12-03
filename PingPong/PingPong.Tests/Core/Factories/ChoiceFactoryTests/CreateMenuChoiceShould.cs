using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.Contracts;
using PingPong.Core.Factories;
using PingPong.Core.Menus.MenuChoices;
using PingPong.Providers.Contracts;

namespace PingPong.Tests.Core.Factories.ChoiceFactoryTests
{
	[TestClass]
	public class CreateMenuChoiceShould
	{
		[TestMethod]
		public void ReturnMenuChoice_WhenParametersAreCorrect()
		{
			//Arrange
			var displayMock = new Mock<IDisplay>();
			displayMock.Setup(d => d.WindowHeight).Returns(100);
			displayMock.Setup(d => d.WindowWidth).Returns(100);
			var commandHolderMock = new Mock<ICommandHolder>();
			IChoiceFactory factory = new ChoiceFactory(displayMock.Object);
			//Act
			var actualChoice = factory.CreateaMenuChoice(
				10, 
				new string[] { "aa", "aa" }, 
				commandHolderMock.Object);
			//Assert
			Assert.IsInstanceOfType(actualChoice, typeof(MenuChoice));
		}
	}
}
