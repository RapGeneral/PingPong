using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Providers.Validation;
using System;

namespace PingPong.Tests.Providers.ValidatorTests
{
	[TestClass]
	public class IsPositiveShould
	{
		[DataTestMethod]
		[DataRow(0)]
		[DataRow(-1)]
		public void Correctly_Throw_ExceptionMessage(int testNum)
		{
			//Arragen & Act & Assert
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => Validator.IsPositive(testNum, "test"),
				"test");
		}

		[TestMethod]
		public void Not_Throw_WithPositiveArgument()
		{
			//Arragen & Act & Assert
			Validator.IsPositive(10, "test");
		}
	}
}
