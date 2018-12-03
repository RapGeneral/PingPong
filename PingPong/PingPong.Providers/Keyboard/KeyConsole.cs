using PingPong.Providers.Contracts;
using System;

namespace PingPong.Providers.Keyboard
{
	public class KeyConsole : IKey
	{
		private readonly ConsoleKeyInfo key;
		internal KeyConsole(ConsoleKeyInfo key)
		{
			this.key = key;
		}
		public bool IsRightArrow()
		{
			return key.Key == ConsoleKey.RightArrow;
		}
		public bool IsLeftArrow()
		{
			return key.Key == ConsoleKey.LeftArrow;
		}
		public bool IsUpArrow()
		{
			return key.Key == ConsoleKey.UpArrow;
		}
		public bool IsDownArrow()
		{
			return key.Key == ConsoleKey.DownArrow;
		}
		public bool IsEnter()
		{
			return key.Key == ConsoleKey.Enter;
		}

		public bool IsN()
		{
			return key.Key == ConsoleKey.N;
		}

		public bool IsY()
		{
			return key.Key == ConsoleKey.Y;
		}
	}
}
