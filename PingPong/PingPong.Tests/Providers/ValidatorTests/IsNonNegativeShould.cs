using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Providers.Validation;
using System;

namespace PingPong.Tests.Providers.ValidatorTests
{
	[TestClass]
	public class IsNonNegativeShould
	{
		[TestMethod]
		public void Correctly_Throw_ExceptionMessage()
		{
			//Arragen & Act & Assert
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => Validator.IsPositive(-1, "test"),
				"test");
		}

		[DataTestMethod]
		[DataRow(0)]
		[DataRow(1)]
		public void Not_Throw_WithNonNegativeArgument(int testNum)
		{
			//Arragen & Act & Assert
			Validator.IsNonNegative(testNum, "test");

		}
	}
}