namespace PingPong.Core.Menus
{
	using PingPong.Core.Contracts;
	using PingPong.Providers.Contracts;
	using PingPong.Providers.Validation;
	using System.Collections.Generic;

	public abstract class Menu : IMenu
    {
        private const string MENU_CHOICES_NULL = "Menu choices cannot be null";
        private const string MENU_CHOICES_EMPTY = "Menu choices cannot be empty";
        private IList<List<IChoice>> itemsLists;
		private int currentChoiceTop;
		private int currentChoiceLeft;
		protected readonly IDisplay display;
		protected readonly IKeyReader keyReader;

		public Menu(IDisplay display, IKeyReader keyReader)
		{
			this.display = display;
			this.keyReader = keyReader;
		}
		protected IList<List<IChoice>> ItemsLists
		{
			get { return this.itemsLists; }
			set
			{
				Validator.IfNull(value, MENU_CHOICES_NULL);
				this.itemsLists = value;
			}
		}
		private void RemoveIndentifier()
		{
			display.WriteAt(itemsLists[currentChoiceTop][currentChoiceLeft].Left, itemsLists[currentChoiceTop][currentChoiceLeft].Top + 1, " ");
			display.WriteAt(itemsLists[currentChoiceTop][currentChoiceLeft].Left, itemsLists[currentChoiceTop][currentChoiceLeft].Top - itemsLists[currentChoiceTop][currentChoiceLeft].Height, " ");
		}
		private void PrintIndentifier()
		{
			this.display.WriteAt(itemsLists[currentChoiceTop][currentChoiceLeft].Left, itemsLists[currentChoiceTop][currentChoiceLeft].Top - itemsLists[currentChoiceTop][currentChoiceLeft].Height, "▼");
			this.display.WriteAt(itemsLists[currentChoiceTop][currentChoiceLeft].Left, itemsLists[currentChoiceTop][currentChoiceLeft].Top + 1, "▲");

		}
		public void RunChoice()
		{
			Validator.IfNull(ItemsLists, MENU_CHOICES_NULL);
			Validator.IsPositive(ItemsLists.Count, MENU_CHOICES_EMPTY);
            currentChoiceTop = 0;
			currentChoiceLeft = 0;
			this.display.SetCursorAt(this.itemsLists[0][0].Left, this.itemsLists[0][0].Top);
			this.PrintIndentifier();
			IKey key;
			do
			{
				key = keyReader.ReadKey(true);
				if (key.IsDownArrow() && currentChoiceTop < itemsLists.Count - 1 && itemsLists[currentChoiceTop + 1].Count > currentChoiceLeft)
				{
					RemoveIndentifier();
					currentChoiceTop++;
					PrintIndentifier();

				}
				else if (key.IsUpArrow() && currentChoiceTop > 0 && itemsLists[currentChoiceTop - 1].Count > currentChoiceLeft)
				{
					RemoveIndentifier();
					currentChoiceTop--;
					PrintIndentifier();
				}
				else if (key.IsLeftArrow() && currentChoiceLeft > 0)
				{
					RemoveIndentifier();
					currentChoiceLeft--;
					PrintIndentifier();
				}
				else if (key.IsRightArrow() && currentChoiceLeft < itemsLists[currentChoiceTop].Count - 1)
				{
					RemoveIndentifier();
					currentChoiceLeft++;
					PrintIndentifier();
				}

			} while (!key.IsEnter());
			this.itemsLists[currentChoiceTop][currentChoiceLeft].CommandHolder.Execute();
		}
		public abstract void Print();
	}
}
