using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PingPong.Core.Contracts;
using PingPong.Core.Factories;
using System;

namespace PingPong.Tests.Core.Factories.CommandFactoryTests
{
    [TestClass]
    public class CreateCommandShould
    {
        private const string arg1 = "test";
        private const string arg2 = "patka";
        [DataTestMethod]
        [DataRow(arg1)]
        [DataRow(arg2)]
        public void ReturnCommandHolderContainingTheRightCommand_WhenSuchExistsAsItem(string argToTest)
        {
            //Arrange
            var parserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();
            commandMock.Setup(c => c.Execute(arg1, arg2));
            parserMock.Setup(p => p.TryParseCommand(argToTest, typeof(ICommand))).Returns((true, commandMock.Object));

            var commandFactory = new CommandFactory(parserMock.Object);
            //Act
            var result = commandFactory.CreateCommand(arg1, arg2);
            //Assert
            result.Execute();
            commandMock.Verify(c => c.Execute(arg1, arg2), Times.Once);
        }

        [TestMethod]
        public void ThrowNotImplementedException_WhenCommandDoesNotExists()
        {
            //Arrange
            var parserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();
            parserMock.Setup(p => p.TryParseCommand("rnd", typeof(ICommand))).Returns((true, commandMock.Object));

            var commandFactory = new CommandFactory(parserMock.Object);
            //Act & Assert
            Assert.ThrowsException<NotImplementedException>(() => commandFactory.CreateCommand("notRND", "notRND2"));
            //Assert
        }
    }
}
