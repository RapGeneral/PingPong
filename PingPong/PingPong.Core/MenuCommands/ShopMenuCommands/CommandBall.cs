namespace PingPong.Core.MenuCommands.ShopMenuCommands
{
    using PingPong.Core.Contracts;
	using PingPong.Core.Menus.Enums;

	public class CommandBall : ICommand
    {
        private readonly IMenu shopBallMenu;
        public CommandBall(IShopItemMenu<BallColors> shopBallMenu)
        {
            this.shopBallMenu = shopBallMenu;
        }
        public void Execute(string enumItem, string enumType)
		{
            this.shopBallMenu.Print();
            this.shopBallMenu.RunChoice();
        }
    }
}
