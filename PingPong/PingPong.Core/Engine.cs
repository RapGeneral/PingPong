namespace PingPong.Core
{
	using System;
    using PingPong.Core.Contracts;
	using PingPong.Core.Menus.Enums;
	using PingPong.Providers.Contracts;

	public class Engine
	{
        private const int DEFAULT_WINDOW_WIDTH = 120;
        private const int DEFAULT_WINDOW_HEIGHT = 30;
		private readonly IKeyReader keyReader;
		private readonly IMenu mainMenu;
		private readonly IDisplay display;

		public Engine(IGameMenu<MainMenuChoices> mainMenu, IDisplay display, IKeyReader keyReader)
		{
			this.keyReader = keyReader;
			this.mainMenu = mainMenu;
			this.display = display;
			this.SetConsoleSettings();
		}
		public void Start()
		{
			try
			{
				while (true)
				{
					this.SetConsoleSettings();
					mainMenu.Print();
                    mainMenu.RunChoice();
					this.display.Clear();
				}
			}
			catch (Exception e)
			{
				this.display.Clear();
                this.display.BufferHeight = 1000;
				this.display.ChangeBackgroundColor("blue");
				this.display.ChangeForegroundColor("white");
				this.display.WriteLine("Oops... Something went wrong. We recommend calling your developer and showing him/her/it the following screen:");
				this.display.WriteLine("Press any key  to see 'the screen'");
				this.keyReader.ReadKey();
				this.display.Write(e.ToString());
				this.keyReader.ReadKey();
				Environment.Exit(0);
			}
		}

		private void SetConsoleSettings()
		{
			this.display.SetOutputEncodingToUTF8();
			this.display.CursorVisible = false;
			this.display.ChangeSize(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT);
			this.display.ChangeBufferSize(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT);
		}
	}
}
