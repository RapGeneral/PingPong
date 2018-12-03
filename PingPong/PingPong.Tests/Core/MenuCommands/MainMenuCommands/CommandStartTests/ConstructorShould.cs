using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.Contracts;
using PingPong.Core.MenuCommands.MainMenuCommands;
using PingPong.Core.Menus.Enums;
using System;

namespace PingPong.Tests.Core.MenuCommands.MainMenuCommands.CommandStartTests
{
	[TestClass]
	public class ConstructorShould
	{
		[TestMethod]
		public void Throw_WhenGameTypeIsNull()
		{
			//Arrange
			var gameType = new Mock<IGameMenu<TypeMenuChoices>>();
			//Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => new CommandStart(null, gameType.Object));
		}

		[TestMethod]
		public void Throw_WhenDifficultyMenuIsNull()
		{
			//Arrange
			var diffMenuMock = new Mock<IGameMenu<DifficultyMenuChoices>>();
			//Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => new CommandStart(diffMenuMock.Object, null));
		}

		[TestMethod]
		public void NotThrow_WhenParametersAreValid()
		{
			//Arrange
			var diffMenuMock = new Mock<IGameMenu<DifficultyMenuChoices>>();
			var gameType = new Mock<IGameMenu<TypeMenuChoices>>();
			//Act & Assert
			new CommandStart(diffMenuMock.Object, gameType.Object);
		}
	}
}
