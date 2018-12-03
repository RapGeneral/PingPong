using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.Contracts;
using PingPong.Core.MenuCommands.MainMenuCommands;
using PingPong.Core.Menus.Enums;

namespace PingPong.Tests.Core.MenuCommands.MainMenuCommands.CommandShopTests
{
	[TestClass]
	public class ExecuteShould
	{
		[TestMethod]
		public void ShouldCallPrint_WhenInvoked()
		{
			//Arrange
			var menuMock = new Mock<IGameMenu<ShopMenuChoices>>();
			var command = new CommandShop(menuMock.Object);
			//Act
			command.Execute("", "");
			//Assert
			menuMock.Verify(m => m.Print(), Times.Once);
		}

		[TestMethod]
		public void ShouldCallRunChoice_WhenInvoked()
		{
			//Arrange
			var menuMock = new Mock<IGameMenu<ShopMenuChoices>>();
			var command = new CommandShop(menuMock.Object);
			//Act
			command.Execute("", "");
			//Assert
			menuMock.Verify(m => m.RunChoice(), Times.Once);
		}
	}
}
