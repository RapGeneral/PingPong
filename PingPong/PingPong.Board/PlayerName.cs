namespace PingPong.Board
{
    using PingPong.Board.Contracts;
	using PingPong.Providers.Validation;

	public class PlayerName : ObjectOnTheBoard, IPlayerName
    {
        private string name;
        private readonly bool nameSide;
		private const string NAME_LENGTH_OUT_OF_RANGE = "Player name is invalid";
		public PlayerName(string name, bool nameSide, IGameBoard gameBoard)
			: base(gameBoard)
        {
            this.Name = name;
            this.nameSide = nameSide;
			if (nameSide)
				for (int i = 0; i < Name.Length; i++)
					gameBoard.Matrix[0, 0 + i] = name[i];
			else
				for (int i = 0; i < Name.Length; i++)
					gameBoard.Matrix[0, gameBoard.Matrix.GetLength(1) - name.Length + i] = name[i];
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
				Validator.IfNull(value);
				Validator.IfIsInRangeInclusive(value.Length, 2, 15, NAME_LENGTH_OUT_OF_RANGE);
                this.name = value;
            }
        }
    }
}
