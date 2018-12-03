namespace PingPong.Core.MenuCommands.DifficultyMenuCommands
{
	using PingPong.Core.Contracts;
    using PingPong.Core.Menus.Enums;
	using PingPong.Game.Contracts;
	using PingPong.Providers.Validation;
	using System;

	public class CommandDifficultyMenuChoices : ICommand
	{
		private readonly IGameParameters parameters;

		public CommandDifficultyMenuChoices(IGameParameters parameters)
		{
			Validator.IfNull(parameters);
			this.parameters = parameters;
		}
		public void Execute(string enumItem, string enumType)
		{
			Validator.IfNull(enumItem);
			Validator.IfNull(enumType);
			this.parameters.Difficulty = (int)Enum.Parse(typeof(DifficultyMenuChoices), enumItem, true);
		}
	}
}
