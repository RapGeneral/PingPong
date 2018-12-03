namespace PingPong.Core.Menus.GameMenus
{
    using System.Collections.Generic;
	using PingPong.Core.Contracts;
	using PingPong.Core.Exceptions;
    using System.Linq;
	using PingPong.Providers.Contracts;
	using PingPong.Providers.Validation;
	using System;

	public class GameMenu<T> : Menu, IGameMenu<T> where T : Enum
	{
		private readonly string[] pingPongTitle;
		private readonly int padTitleSide;
        private const int PAD_TITLE_TOP = 1;
        private const string TITLE = "Ping Pong";
        private const byte SPACE_BETWEEN_TITLE_WORDS = 7;
        private const byte INTITIAL_HIGHT = 14;
        private const string ENUM_EMPTY = "Enum cannot be empty!";
        private const string CONSOLE_SPACE_NEGATIVE = "Not enough space on the console!";
        private const string MENU_OPTIONS_NULL = "You must first load the menu!";
		private const string BIGWORDS_NULL = "BigWords cannot be null!";

        public GameMenu(ICommandFactory factory, 
						IBigFont bigFont, 
						IMediumFont mediumFont, 
						IDisplay display, 
						IKeyReader keyReader, 
						IBigWords bigWords, 
						IChoiceFactory chocieFactory)
			: base(display, keyReader)
		{
			Validator.IfNull(factory, MENU_OPTIONS_NULL);
			Validator.IfNull(mediumFont, MENU_OPTIONS_NULL);
			Validator.IfNull(bigFont, MENU_OPTIONS_NULL);
			Validator.IfNull(bigWords, BIGWORDS_NULL);

            string[] options = Enum.GetNames(typeof(T));
            Validator.IsPositive(options.Length, ENUM_EMPTY);

            IList<ICommandHolder> commands = factory.CreateCommands(options, typeof(T).ToString().Split('.').Last());
			this.ItemsLists = new List<List<IChoice>>();
			//List of lists of menu items
			//GameMenu consists only of 1 item per line
			//So N (1 per line) lists with 1 item are needed.
			for (int i = 0; i < commands.Count; i++)
			{
				this.ItemsLists.Add(new List<IChoice>());
				this.ItemsLists[i].Add(chocieFactory.CreateaMenuChoice(INTITIAL_HIGHT + i * (mediumFont.LetterHeight + 1),
					bigWords.MakeItBig(options[i], mediumFont),
                    commands[i]
                    ));
			}

			pingPongTitle = bigWords.MakeItBig(TITLE, bigFont, SPACE_BETWEEN_TITLE_WORDS);
			padTitleSide = (this.display.WindowWidth - pingPongTitle[0].Length) / 2 + (display.WindowWidth - pingPongTitle[0].Length) % 2;
			if (padTitleSide < 0)
				throw new NotEnoughDisplaySpaceException(CONSOLE_SPACE_NEGATIVE);
		}
		private void PrintTitle()
		{
			this.display.SetCursorAt(0, PAD_TITLE_TOP);
			for (int i = 0; i < pingPongTitle.Length; i++)
				this.display.WriteLine(new string(' ', padTitleSide) + pingPongTitle[i]);
		}
		public override void Print()
		{
			this.display.Clear();
			PrintTitle();
			for (int i = 0; i < this.ItemsLists.Count; i++)
			{
				this.ItemsLists[i][0].PrintChoice();
				this.display.WriteLine();
			}
		}
	}
}