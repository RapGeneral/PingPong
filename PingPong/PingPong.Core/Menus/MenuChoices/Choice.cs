using PingPong.Core.Contracts;
using PingPong.Providers.Contracts;
using PingPong.Providers.Validation;

namespace PingPong.Core.Menus.MenuChoices
{
    public abstract class Choice : IChoice
    {
        private const string CHOICE_COORDS_NOT_VALID = "The choice's coordinates are not valid!";
        private const string COMMAND_NULL = "The command cannot be null!";
		private const string DISPLAY_NULL = "The display cannot be null!";

		public int Left { get; }
        public int Top { get; }
        public int Height { get; }
        public ICommandHolder CommandHolder { get; }
		public abstract void PrintChoice();
		protected IDisplay display;
		public Choice(int top, int left, ICommandHolder commandHolder, int height, IDisplay display)
		{
			Validator.IfIsInRangeInclusive(Left, 0, display.WindowWidth - 1, CHOICE_COORDS_NOT_VALID);
			Validator.IfIsInRangeInclusive(Top, 0, display.WindowHeight - 1, CHOICE_COORDS_NOT_VALID);
			Validator.IfIsInRangeInclusive(Height, 0, display.WindowHeight - 1, CHOICE_COORDS_NOT_VALID);
			Validator.IfNull(commandHolder, COMMAND_NULL);
			Validator.IfNull(display, DISPLAY_NULL);

			this.display = display;
            this.CommandHolder = commandHolder;
			this.Top = top;
			this.Left = left;
			this.Height = height;
		}
    }
}
