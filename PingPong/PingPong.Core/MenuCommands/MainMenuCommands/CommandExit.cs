namespace PingPong.Core.MenuCommands.MainMenuCommands
{
	using PingPong.Core.Contracts;
    using System;

	public class CommandExit : ICommand
	{
		public void Execute(string enumItem, string enumType)
		{
			Environment.Exit(0);
		}
	}
}
