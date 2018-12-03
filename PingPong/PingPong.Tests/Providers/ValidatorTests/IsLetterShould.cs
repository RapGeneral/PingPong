using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Providers.Validation;
using System;

namespace PingPong.Tests.Providers.ValidatorTests
{
	[TestClass]
	public class IsLetterShould
	{
		[DataTestMethod]
		[DataRow('1')]
		[DataRow('@')]
		[DataRow('	')]
		[DataRow(' ')]
		public void Correctly_Throw_ExceptionMessage(char testChar)
		{
			//Arragen & Act & Assert
			Assert.ThrowsException<ArgumentException>(
				() => Validator.IsLetter(testChar, "test"), 
				"test");
		}

		[TestMethod]
		public void Not_Throw_Exception_WithLetterArgument()
		{
			//Arragen & Act & Assert
			Validator.IsLetter('a', "somemsg");
		}
	}
}
