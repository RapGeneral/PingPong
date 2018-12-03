namespace PingPong.Core.MenuCommands.MainMenuCommands
{
    using PingPong.Core.Contracts;
	using PingPong.Core.Menus.Enums;
	using PingPong.Providers.Validation;

	public class CommandStart : ICommand
    {
        private readonly IMenu difficultyMenu;
        private readonly IMenu gameTypeMenu;
        public CommandStart(IGameMenu<DifficultyMenuChoices> difficultyMenu, IGameMenu<TypeMenuChoices> gameTypeMenu)
        {
			Validator.IfNull(difficultyMenu);
			Validator.IfNull(gameTypeMenu);
			this.difficultyMenu = difficultyMenu;
            this.gameTypeMenu = gameTypeMenu;
        }
        public void Execute(string enumItem, string enumType)
		{
            this.difficultyMenu.Print();
            this.difficultyMenu.RunChoice();
            this.gameTypeMenu.Print();
            this.gameTypeMenu.RunChoice();
        }
    }
}
