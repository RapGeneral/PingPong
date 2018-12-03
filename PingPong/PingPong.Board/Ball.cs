namespace PingPong.Board
{
	using PingPong.Board.Contracts;
    using System;

    public class Ball : ObjectOnTheBoard, IBall
	{
		private int moveLeft;
		private int moveTop;
		private bool canMove;
		private bool exitSide;
        private Random randomDirection = new Random();
		public Ball(IGameBoard gameBoard)
			: base(gameBoard)
		{
			this.canMove = true;
			//StartingCoordinates
			this.Left = gameBoard.Matrix.GetLength(1) / 2;
			this.Top = gameBoard.Matrix.GetLength(0) / 2;
		}
        public void StartDirectionBall()
        {
            moveLeft = randomDirection.Next(-1, 2);
            moveTop = randomDirection.Next(-1, 2);
            if (moveLeft == 0 || moveTop == 0)
            {
                StartDirectionBall();
                return;
            }
        }
		public void Restart()
		{
			this.Left = gameBoard.Matrix.GetLength(1) / 2;
			this.Top = gameBoard.Matrix.GetLength(0) / 2;
            StartDirectionBall();
			this.CanMove = true;
			this.ExitSide = false;
            
        }
		public bool CanMove
		{
			get
			{
				return this.canMove;
			}
			private set
			{
				this.canMove = value;
			}

		}
		public bool ExitSide
		{
			get
			{
				return this.exitSide;
			}
			private set
			{
				this.exitSide = value;
			}
		}

		public void Move()
		{
			if (!CanMove)
				return;
            if (moveLeft == 0)
            {
                StartDirectionBall();
            }
            if (this.Left + moveLeft < 0)
			{
				CanMove = false;
				return;
			}
			if (this.Left + moveLeft >= gameBoard.Matrix.GetLength(1))
			{
				CanMove = false;
				ExitSide = true;
				return;
			}

			if (gameBoard.Matrix[Top + moveTop, this.Left + moveLeft] == '=')
			{
				moveTop = -moveTop;
				this.Move();
				return;
			}
            if (gameBoard.Matrix[Top + moveTop, this.Left + moveLeft] == '*')
            {
                moveLeft = -1;
                moveTop = -1;
                this.Move();
                return;
            }
            else if (gameBoard.Matrix[Top + moveTop, this.Left + moveLeft] == '█')
            {
                moveLeft = -moveLeft;
                this.Move();
                return;
            }
			gameBoard.Matrix[Top, this.Left] = ' ';
			this.Left += moveLeft;
			this.Top += moveTop;
			gameBoard.Matrix[Top, this.Left] = '@';
		}
	}
}
