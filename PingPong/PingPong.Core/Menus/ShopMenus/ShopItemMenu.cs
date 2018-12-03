namespace PingPong.Core.Menus.ShopMenus
{
    using PingPong.Core.Contracts;
    using System.Collections.Generic;
    using PingPong.Core.Exceptions;
    using System.Linq;
	using PingPong.Providers.Contracts;
	using PingPong.Providers.Validation;
	using System;

	public class ShopItemMenu<T> : Menu, IShopItemMenu<T> where T : Enum
    {
        private const int SHOP_ITEM_WIDTH = 3;
        private const int SPACE_BETWEEN_SHOP_ITEMS = 6;
        private const int SPACE_BETWEEN_SHOP_ITEM_LINES = 5;
        private const int PAD_SHOP_ITEMS = 10;
        private const int INITIAL_HEIGHT = 15;
        private const int PAD_TITLE_TOP = 1;
        private const int SPACES_BETWEEN_WORDS_IN_TITLE = 6;
		private const string BIG_WRODS_NULL = "bigWords cannot be null!";
		private const string SHOP_ITEM_MENU_TITLE = "Select item";
        private const string FONT_NULL = "The font cannot be null!";
        private const string CONSOLE_SPACE_NEGATIVE = "Not enough space on the console!";
        private const string COMMAND_FACTORY_NULL = "The command factory cannot be null!";
		private const string COLLOR_TO_NOT_BE_USED = "black";

        private readonly IMediumFont mediumFont;
		private readonly IBigWords bigWords;

		public ShopItemMenu(IMediumFont mediumFont, 
							ICommandFactory factory, 
							IDisplay display, 
							IKeyReader keyReader, 
							IBigWords bigWords, 
							IChoiceFactory choiceFactory)
			: base(display, keyReader)
		{
            Validator.IfNull(mediumFont, FONT_NULL);
            Validator.IfNull(factory, COMMAND_FACTORY_NULL);
			Validator.IfNull(bigWords, BIG_WRODS_NULL);
			this.bigWords = bigWords;
			this.mediumFont = mediumFont;

            string[] enumItems = Enum.GetNames(typeof(T));

            IList<ICommandHolder> commands = factory.CreateCommands(enumItems, typeof(T).ToString().Split('.').Last());
            for (int i = 0; i < commands.Count; i++)
                if (commands[i].EnumItem.ToLower() == COLLOR_TO_NOT_BE_USED)
                    commands.Remove(commands[i--]);

            int itemsPerLine = (this.display.WindowWidth - 2 * PAD_SHOP_ITEMS + SPACE_BETWEEN_SHOP_ITEMS + 1) / (SHOP_ITEM_WIDTH + SPACE_BETWEEN_SHOP_ITEMS);
            if (itemsPerLine < 0)
                throw new NotEnoughDisplaySpaceException(CONSOLE_SPACE_NEGATIVE);

            this.CreateChoices(commands, choiceFactory, itemsPerLine);

        }
        private void CreateChoices(IList<ICommandHolder> commands, IChoiceFactory choiceFactory ,int itemsPerLine)
        {
            this.ItemsLists = new List<List<IChoice>>();
            int line = 0, br = 0;
            for (int i = 0; i < commands.Count; i++)
            {
                if (br == 0) this.ItemsLists.Add(new List<IChoice>());
                if (br == itemsPerLine)
                {
                    this.ItemsLists.Add(new List<IChoice>());
                    br = 0;
                    line++;
                }
                this.ItemsLists[line].Add(choiceFactory.CreateaShopChoice(INITIAL_HEIGHT + SPACE_BETWEEN_SHOP_ITEM_LINES * line,
                                                         PAD_SHOP_ITEMS + br * (SPACE_BETWEEN_SHOP_ITEMS + SHOP_ITEM_WIDTH),
                                                         commands[i]));
                br++;
            }
        }
        public override void Print()
        {
			this.display.Clear();
			this.display.SetCursorAt(0, PAD_TITLE_TOP);
            string[] title = this.bigWords.MakeItBig(SHOP_ITEM_MENU_TITLE, mediumFont, SPACES_BETWEEN_WORDS_IN_TITLE);
            for (int i = 0; i < title.Length; i++)
            {
                this.display.WriteLine(new string(' ', (this.display.WindowWidth - title[0].Length) / 2) + title[i]);
            }
            foreach (var list in this.ItemsLists)
                foreach (IChoice item in list)
                {
                    item.PrintChoice();
                }
            this.display.ResetColor();
        }
    }
}
