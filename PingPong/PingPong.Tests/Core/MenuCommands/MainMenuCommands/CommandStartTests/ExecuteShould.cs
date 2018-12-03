using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.Contracts;
using PingPong.Core.MenuCommands.MainMenuCommands;
using PingPong.Core.Menus.Enums;

namespace PingPong.Tests.Core.MenuCommands.MainMenuCommands.CommandStartTests
{
	[TestClass]
	public class ExecuteShould
	{
		[TestMethod]
		public void ShouldCallDiffMenuPrint_WhenInvoked()
		{
			//Arrange
			var diffMenuMock = new Mock<IGameMenu<DifficultyMenuChoices>>();
			var gameType = new Mock<IGameMenu<TypeMenuChoices>>();
			var command = new CommandStart(diffMenuMock.Object, gameType.Object);
			//Act
			command.Execute("", "");
			//Assert
			diffMenuMock.Verify(m => m.Print(), Times.Once);
		}

		[TestMethod]
		public void ShouldCallDiffMenuRunChoice_WhenInvoked()
		{
			//Arrange
			var diffMenuMock = new Mock<IGameMenu<DifficultyMenuChoices>>();
			var gameType = new Mock<IGameMenu<TypeMenuChoices>>();
			var command = new CommandStart(diffMenuMock.Object, gameType.Object);
			//Act
			command.Execute("", "");
			//Assert
			diffMenuMock.Verify(m => m.RunChoice(), Times.Once);
		}
		[TestMethod]
		public void ShouldCallTypeMenuPrint_WhenInvoked()
		{
			//Arrange
			var diffMenuMock = new Mock<IGameMenu<DifficultyMenuChoices>>();
			var gameType = new Mock<IGameMenu<TypeMenuChoices>>();
			var command = new CommandStart(diffMenuMock.Object, gameType.Object);
			//Act
			command.Execute("", "");
			//Assert
			gameType.Verify(m => m.Print(), Times.Once);
		}

		[TestMethod]
		public void ShouldCallTypeMenuRunChoice_WhenInvoked()
		{
			//Arrange
			var diffMenuMock = new Mock<IGameMenu<DifficultyMenuChoices>>();
			var gameType = new Mock<IGameMenu<TypeMenuChoices>>();
			var command = new CommandStart(diffMenuMock.Object, gameType.Object);
			//Act
			command.Execute("", "");
			//Assert
			gameType.Verify(m => m.RunChoice(), Times.Once);
		}
	}
}
