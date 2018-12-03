namespace PingPong.Core.MenuCommands.ShopMenuCommands
{
    using PingPong.Core.Contracts;
	using PingPong.Core.Menus.Enums;

	public class CommandLine : ICommand
    {
        private readonly IMenu shopLineMenu;
        public CommandLine(IShopItemMenu<LineColors> shopLineMenu)
        {
            this.shopLineMenu = shopLineMenu;
        }
        public void Execute(string enumItem, string enumType)
		{
            this.shopLineMenu.Print();
            this.shopLineMenu.RunChoice();
        }
    }
}
