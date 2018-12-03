using PingPong.Core.Contracts;
using PingPong.Core.Menus.MenuChoices;
using PingPong.Providers.Contracts;
using PingPong.Providers.Validation;

namespace PingPong.Core.Factories
{
	public class ChoiceFactory : IChoiceFactory
	{
		private readonly IDisplay display;
		public ChoiceFactory(IDisplay display)
		{
			Validator.IfNull(display);
			this.display = display;
		}
		public IChoice CreateaMenuChoice(int top, string[] nameToPrint, ICommandHolder commandHolder)
		{
			return new MenuChoice(top, nameToPrint, commandHolder, this.display);
		}
		public IChoice CreateaShopChoice(int top, int left, ICommandHolder commandHolder)
		{
			return new ShopChoice(top, left, commandHolder, this.display);
		}
	}
}

