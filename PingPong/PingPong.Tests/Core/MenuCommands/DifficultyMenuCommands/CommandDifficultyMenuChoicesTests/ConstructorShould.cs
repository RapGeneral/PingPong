using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.MenuCommands.DifficultyMenuCommands;
using PingPong.Game.Contracts;
using System;

namespace PingPong.Tests.Core.MenuCommands.DifficultyMenuCommands.CommandDifficultyMenuChoicesTests
{
	[TestClass]
	public class ConstructorShould
	{
		[TestMethod]
		public void Throw_WhenParametersAreNull()
		{
			//Arrange & Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => new CommandDifficultyMenuChoices(null));
		}

		[TestMethod]
		public void NotThrow_WhenParametersAreValid()
		{
			//Arrange
			var parametersMock = new Mock<IGameParameters>();
			//Act & Assert
			new CommandDifficultyMenuChoices(parametersMock.Object);
		}
	}
}
