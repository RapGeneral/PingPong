using PingPong.Core.Contracts;
using PingPong.Providers.Validation;

namespace PingPong.Core.Menus.MenuChoices
{
    public class CommandHolder : ICommandHolder
    {
		private readonly ICommand Command;
		public string EnumItem { get; }
		public string EnumType { get; }

		public CommandHolder(ICommand command, string enumItem, string enumType)
		{
			Validator.IfNull(command);
			Validator.IfNull(enumItem);
			Validator.IfNull(enumType);

			this.Command = command;
			this.EnumItem = enumItem;
			this.EnumType = enumType;
        }

        public void Execute()
        {
            this.Command.Execute(EnumItem, EnumType);
        }
    }
}
