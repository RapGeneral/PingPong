namespace PingPong.Board
{
    using PingPong.Board.Contracts;
	using PingPong.Providers.Validation;

	public class PlayerLine : ObjectOnTheBoard, IPlayerLine
    {
        private int length;
		private const string PLAYER_LINE_LENGTH_OUT_OF_RANGE = "Too short or too long player line";
		public int Length
        {
            get
            {
                return this.length;
            }
            set
            {
				Validator.IfNull(value);
				Validator.IfIsInRangeInclusive(value, 1, gameBoard.Matrix.GetLength(0) - 5, PLAYER_LINE_LENGTH_OUT_OF_RANGE);
                this.length = value;
            }
        }

		public PlayerLine(IGameBoard gameBoard, bool possition, int length) 
			: base(gameBoard)//0 - left, 1 right
        {
            this.Length = length;

            if (possition)
            {
                this.Left = gameBoard.Matrix.GetLength(1) - 1;
            }
            else
            {
                this.Left = 0;
            }
            this.Top = gameBoard.Matrix.GetLength(0) / 2 - Length / 2 - 1;

			for (int i = 0; i < Length; i++)
				gameBoard.Matrix[Top + i, Left] = '█';
		}

        public void Move(bool direction) //0 - down, 1 up
        {
            if (direction)
            {
                if (Top == 2)
                {
                    return;
                }
				gameBoard.Matrix[Top + Length - 1, Left] = ' ';
                gameBoard.Matrix[Top - 1, Left] = '█';
				Top--;
			}
            else
            {
                if (Top  + Length - 1 == gameBoard.Matrix.GetLength(0) - 4)
                {
                    return;
                }
				gameBoard.Matrix[Top, Left] = ' ';
                gameBoard.Matrix[Top + Length, Left] = '█';
				Top++;
			}

        }
		public void Restart()
		{
			for (int i = 0; i < Length; i++)
			{
				gameBoard.Matrix[Top + i, Left] = ' ';
				this.Top = gameBoard.Matrix.GetLength(0) / 2 - Length / 2 - 1;
			}
			for (int i = 0; i < Length; i++)
				gameBoard.Matrix[Top + i, Left] = '█';
		}
    }
}
