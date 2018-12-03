using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Providers.Validation;
using System;

namespace PingPong.Tests.Providers.ValidatorTests
{
	[TestClass]
	public class IfNullShould
	{
		[TestMethod]
		public void Correctly_Throw_Exception()
		{
			//Arragen & Act & Assert
			Assert.ThrowsException<ArgumentNullException>(() => Validator.IfNull(null));
		}

		[TestMethod]
		public void Correctly_Throw_ExceptionMessage()
		{
			//Arragen & Act & Assert
			Assert.ThrowsException<ArgumentNullException>(
				() => Validator.IfNull(null, "test"), 
				"test");
		}

		[TestMethod]
		public void Not_Throw_Exception_WithNonNullArgument()
		{
			//Arragen & Act & Assert
			Validator.IfNull("notnull");
		}
	}
}
