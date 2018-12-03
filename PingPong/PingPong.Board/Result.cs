using System;

namespace PingPong.Board
{
	using PingPong.Board.Contracts;
	using PingPong.Providers.Validation;

	public class Result : ObjectOnTheBoard, IResult
	{
        private int leftResult;
        private int rightResult;
		private const string RESULT_OUT_OF_RANGE = "Left result out of range!";
		public Result(IGameBoard gameBoard, int leftResult = 0, int rightResult = 0)
			: base(gameBoard)
        {
            this.LeftResult = leftResult;
            this.RightResult = rightResult;
			gameBoard.Matrix[0, gameBoard.Matrix.GetLength(1) / 2 - 2] = '0';
			gameBoard.Matrix[0, gameBoard.Matrix.GetLength(1) / 2 - 1] = ':';
			gameBoard.Matrix[0, gameBoard.Matrix.GetLength(1) / 2] = '0';
		}

		public int LeftResult
        {
			get => this.leftResult;
            set
            {
				Validator.IfIsInRangeInclusive(value, 0, 9, RESULT_OUT_OF_RANGE);
                this.leftResult = value;
            }
        }

		public int RightResult
        {
			get => this.rightResult;
            set
            {
				Validator.IfIsInRangeInclusive(value, 0, 9, RESULT_OUT_OF_RANGE);
				this.rightResult = value;
            }
        }

        public void IncreaseLeft()
		{
            LeftResult++;
			gameBoard.Matrix[0, gameBoard.Matrix.GetLength(1) / 2 - 2] = Char.Parse(LeftResult.ToString());
		}

		public void IncreaseRight()
		{
            RightResult++;
			gameBoard.Matrix[0, gameBoard.Matrix.GetLength(1) / 2] = Char.Parse(RightResult.ToString());
		}
	}
}
