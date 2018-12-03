using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Providers.Validation;
using System;

namespace PingPong.Tests.Providers.ValidatorTests
{
	[TestClass]
	public class IfIsInRangeInclusiveShould
	{
		[DataTestMethod]
		[DataRow(3)]
		[DataRow(-3)]
		public void Correctly_Throw_ExceptionMessage(int testNum)
		{
			//Arragen & Act & Assert
			Assert.ThrowsException<ArgumentOutOfRangeException>(
				() => Validator.IfIsInRangeInclusive(testNum, -2, 2, "test"),
				"test");

            
		}

		[DataTestMethod]
		[DataRow(2)]
		[DataRow(-2)]
		[DataRow(-0)]
		public void Not_Throw_Exception_WithInRangeArguments(int testNum)
		{
			//Arragen & Act & Assert
			Validator.IfIsInRangeInclusive(testNum, -2, 2, "test");
		}
	}
}
