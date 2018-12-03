namespace PingPong.Board
{
	using PingPong.Board.Contracts;
	using PingPong.Providers.Validation;

	public abstract class ObjectOnTheBoard : IObjectOnTheBoard
	{
		private int left;
		private int top;
		protected readonly IGameBoard gameBoard;
		private const string FILED_OBJECT_OUT_OF_RAGNGE = "Board object parameter out of range!";
		public ObjectOnTheBoard(IGameBoard gameBoard)
		{
			Validator.IfNull(gameBoard);
			this.gameBoard = gameBoard;
		}
		public virtual int Top
		{
			get
			{
				return this.top;
			}
			protected set
			{
				Validator.IfIsInRangeInclusive(value, 0, gameBoard.Matrix.GetLength(0), FILED_OBJECT_OUT_OF_RAGNGE);
				this.top = value;
			}
		}

		public virtual int Left
		{
			get
			{
				return this.left;
			}
			protected set
			{
				Validator.IfIsInRangeInclusive(value, 0, gameBoard.Matrix.GetLength(1), FILED_OBJECT_OUT_OF_RAGNGE);
				this.left = value;
			}
		}
	}
}
