namespace PingPong.Core.MenuCommands.TypeMenuCommands
{
	using PingPong.Board.Contracts;
	using PingPong.Core.Contracts;
    using PingPong.Game;
	using PingPong.Game.Contracts;
	using PingPong.Providers.Contracts;

	public class CommandClassic : ICommand
    {
        private readonly IGameEndScreen endScreen;
        private readonly IGameParameters gameParams;
		private readonly IBoardFactory factory;
        private readonly IDisplay display;
        private readonly IKeyReader keyReader;

        public CommandClassic(IGameParameters gameParams, IBoardFactory factory, IGameEndScreen endScreen, IDisplay display, IKeyReader keyReader) 
        {
            this.display = display;
            this.keyReader = keyReader;
            this.endScreen = endScreen;
			this.gameParams = gameParams;
			this.factory = factory;
		}

        public void Execute(string enumItem, string enumType)
		{
			Classic game = new Classic(gameParams, factory, this.display, this.keyReader);
			game.Run();
            this.endScreen.End(game.Winner);
        }
    }
}
