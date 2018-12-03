namespace PingPong.Core.Factories
{
    using PingPong.Core.Contracts;
	using PingPong.Core.Menus.MenuChoices;
    using PingPong.Providers.Validation;
	using System;
	using System.Collections.Generic;

    public class CommandFactory : ICommandFactory
    {

        private const string FONT_NULL = "The font cannot be null!";
        private const string ENUM_EMPTY = "Enum cannot be empty!";
        private const string PARSER_NULL = "Parser cannot be null!";
        private const string COMMAND_NOT_IMPLEMENTED = "The command has not been implemented yet!";
        private readonly ICommandParser parser;
        public CommandFactory(ICommandParser parser)
        {
            Validator.IfNull(parser, PARSER_NULL);
            this.parser = parser;
        }
        public ICommandHolder CreateCommand(string enumItem, string enumType)
        {
            (bool, object) parsed = this.parser.TryParseCommand(enumItem.ToLower(), typeof(ICommand));
            if (parsed.Item1)
                return new CommandHolder((ICommand)parsed.Item2, enumItem, enumType);
            else
            {
                parsed = this.parser.TryParseCommand(enumType.ToLower(), typeof(ICommand));
                if(parsed.Item1)
                    return new CommandHolder((ICommand)parsed.Item2, enumItem, enumType);
                else
                    throw new NotImplementedException(COMMAND_NOT_IMPLEMENTED);
            }
        }
		public IList<ICommandHolder> CreateCommands(string[] enumItems, string enumType)
		{
			Validator.IsPositive(enumItems.Length, ENUM_EMPTY);
			IList<ICommandHolder> commandList = new List<ICommandHolder>();
			foreach (var enumItem in enumItems)
			{
				commandList.Add(this.CreateCommand(enumItem, enumType));
			}
			return commandList;
		}
	}
}
