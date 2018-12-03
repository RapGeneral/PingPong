using PingPong.Core.Contracts;
using PingPong.Providers.Contracts;
using PingPong.Providers.Validation;
using System.Threading;

namespace PingPong.Core.MenuCommands.Abstract
{
    public class GameEndScreen : IGameEndScreen
    {

        private const int DEFAULT_WINDOW_WIDTH = 120;
        private const int DEFAULT_WINDOW_HEIGHT = 30;
        private const string WIN_SCREEN = "You win";
        private const string LOSS_SCREEN = "You lose";
        private const int PAD_END_SCREEN_TOP = 12;
        private const int SPACE_BETWEEN_END_SCREEN_WORDS = 5;
        private const string WIN_SCREEN_COLOR = "green";
        private const string LOSS_SCREEN_COLOR = "red";


        private readonly IMediumFont mediumFont;
		private readonly IBigWords bigWords;
		protected readonly IDisplay display;
		protected readonly IKeyReader keyReader;

		public GameEndScreen(IMediumFont mediumFont, IBigWords bigWords, IDisplay display, IKeyReader keyReader)
        {
			Validator.IfNull(mediumFont);
			Validator.IfNull(bigWords);
			Validator.IfNull(display);
			Validator.IfNull(keyReader);

			this.mediumFont = mediumFont;
			this.bigWords = bigWords;
			this.display = display;
			this.keyReader = keyReader;
        }
        public void End(bool winner)
        {
            this.display.ChangeSize(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT);
            this.display.ChangeBufferSize(DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT);
            this.display.Clear();
            this.display.SetCursorAt(0, PAD_END_SCREEN_TOP);
            if (winner)
            {
				this.display.ChangeForegroundColor(LOSS_SCREEN_COLOR);
                foreach (string line in this.bigWords.MakeItBig(LOSS_SCREEN, this.mediumFont, SPACE_BETWEEN_END_SCREEN_WORDS))
					this.display.WriteLine(new string(' ', (this.display.WindowWidth - line.Length) / 2 + (this.display.WindowWidth - line.Length) % 2) + line);
            }
            else
            {
				this.display.ChangeForegroundColor(WIN_SCREEN_COLOR);
                foreach (string line in this.bigWords.MakeItBig(WIN_SCREEN, this.mediumFont, SPACE_BETWEEN_END_SCREEN_WORDS))
					this.display.WriteLine(new string(' ', (this.display.WindowWidth - line.Length) / 2 + (this.display.WindowWidth - line.Length) % 2) + line);
            }
            this.keyReader.ReadKey();
			Thread.Sleep(1000);
            this.display.ResetColor();
        }
    }
}
