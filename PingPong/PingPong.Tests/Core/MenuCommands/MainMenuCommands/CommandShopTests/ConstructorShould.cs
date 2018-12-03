using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.Contracts;
using PingPong.Core.MenuCommands.MainMenuCommands;
using PingPong.Core.Menus.Enums;
using System;

namespace PingPong.Tests.Core.MenuCommands.MainMenuCommands.CommandShopTests
{
	[TestClass]
	public class ConstructorShould
	{
		[TestMethod]
		public void Throw_WhenParametersAreNull()
		{
			//Arrange & Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => new CommandShop(null));
		}

		[TestMethod]
		public void NotThrow_WhenParametersAreValid()
		{
			//Arrange
			var menuMock = new Mock<IGameMenu<ShopMenuChoices>>();
			//Act & Assert
			new CommandShop(menuMock.Object);
		}
	}
}
