namespace PingPong.Core.Exceptions
{
	using System;
	class NotEnoughDisplaySpaceException : Exception
    {
		public NotEnoughDisplaySpaceException(string message)
		: base(message)
		{}

		public NotEnoughDisplaySpaceException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
