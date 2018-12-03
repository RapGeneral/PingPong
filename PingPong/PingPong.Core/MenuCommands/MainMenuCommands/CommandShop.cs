namespace PingPong.Core.MenuCommands.MainMenuCommands
{
    using PingPong.Core.Contracts;
	using PingPong.Core.Menus.Enums;
	using PingPong.Providers.Validation;

	public class CommandShop : ICommand
    {
        private readonly IMenu shopMenu;
        public CommandShop(IGameMenu<ShopMenuChoices> shopMenu)
        {
			Validator.IfNull(shopMenu);
            this.shopMenu = shopMenu;
        }
        public void Execute(string enumItem, string enumType)
		{
			this.shopMenu.Print();
            this.shopMenu.RunChoice();
        }
    }
}
