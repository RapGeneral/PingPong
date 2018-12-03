namespace PingPong.Core.Menus.MenuChoices
{
	using PingPong.Core.Contracts;
	using PingPong.Providers.Contracts;
	using System;
	public class ShopChoice : Choice
	{
        private const int SHOP_ITEM_HEIGHT = 2;

        public ShopChoice(int top, int left, ICommandHolder commandHolder, IDisplay display) 
			: base(top, left, commandHolder, SHOP_ITEM_HEIGHT, display)
		{ }
		public override void PrintChoice()
		{
			this.display.ChangeForegroundColor(this.CommandHolder.EnumItem);
			this.display.SetCursorAt(this.Left - 1, this.Top + 2);
			this.display.Write("100$");
			this.display.SetCursorAt(this.Left - 1, this.Top - 1);
			this.display.Write("███");
			this.display.SetCursorAt(this.Left - 1, this.Top);
			this.display.Write("███");
		}
	}
}
