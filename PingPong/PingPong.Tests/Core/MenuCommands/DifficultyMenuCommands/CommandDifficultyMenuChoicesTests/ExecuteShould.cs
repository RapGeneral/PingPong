using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.MenuCommands.DifficultyMenuCommands;
using PingPong.Game.Contracts;
using System;

namespace PingPong.Tests.Core.MenuCommands.DifficultyMenuCommands.CommandDifficultyMenuChoicesTests
{
	[TestClass]
	public class ExecuteShould
	{
		[TestMethod]
		public void Throw_WhenEnumTypeIsNull()
		{
			//Arrange
			var parametersMock = new Mock<IGameParameters>();
			var command = new CommandDifficultyMenuChoices(parametersMock.Object);
			//Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => command.Execute(null, ""));
		}

		[TestMethod]
		public void Throw_WhenEnumItemIsNull()
		{
			//Arrange
			var parametersMock = new Mock<IGameParameters>();
			var command = new CommandDifficultyMenuChoices(parametersMock.Object);
			//Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => command.Execute("", null));
		}

		[TestMethod]
		public void UpdateDifficulty()
		{
			//Arrange
			var parametersMock = new Mock<IGameParameters>();
			var command = new CommandDifficultyMenuChoices(parametersMock.Object);
			//Act
			command.Execute("75", "");
			//Assert
			parametersMock.VerifySet(p => p.Difficulty = 75);
		}
	}
}
