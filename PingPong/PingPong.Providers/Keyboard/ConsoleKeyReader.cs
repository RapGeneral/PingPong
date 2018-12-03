using PingPong.Providers.Contracts;
using System;

namespace PingPong.Providers.Keyboard
{
	public class ConsoleKeyReader : IKeyReader
	{
		public IKey ReadKey(bool intercept = false)
		{
			return new KeyConsole(Console.ReadKey(intercept));
		}
	}
}
