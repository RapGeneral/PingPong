namespace PingPong.Game
{
	using PingPong.Game.Contracts;
	using System;
	using PingPong.Board;
	using System.Threading;
	using PingPong.Board.Contracts;
	using PingPong.Providers.Contracts;
	using PingPong.Providers.Validation;
	using System.Collections.Generic;

	public class Classic
	{
		private readonly IGameBoard gameBoard;
		private readonly IPlayerLine player;
		private readonly IPlayerLine computer;
		private readonly IPlayerName PlayerOne;
		private readonly IPlayerName PlayerTwo;
		private readonly IResult result;
		private readonly IBall ball;


        private Thread ballMovementThread;
		private Thread computerMovementThread;
		private Thread printingThread;

		private readonly IDisplay display;
		private readonly IKeyReader keyReader;
		private readonly IGameParameters parameters;

		private const int playerLineLength = 5;
		private const int maxPossiblePoints = 7;
		private const string DEFAULT_COLOR = "white";
		public bool Winner { get; private set; }

		public Classic(IGameParameters parameters, IBoardFactory factory, IDisplay display, IKeyReader keyReader)
		{
			Validator.IfNull(display);
			Validator.IfNull(keyReader);
			Validator.IfNull(parameters);
			Validator.IfNull(factory);

			this.display = display;
			this.keyReader = keyReader;
			this.parameters = parameters;

			this.display.ChangeSize(this.parameters.Left, this.parameters.Top - 2);
			this.display.ChangeBufferSize(this.parameters.Left, this.parameters.Top - 2);

			this.gameBoard = factory.CreateBoard(parameters.Top, parameters.Left);
			this.result = factory.CreateResult(gameBoard);
			this.player = factory.CreatePlayerLine(gameBoard, false, playerLineLength);
			this.computer = factory.CreatePlayerLine(gameBoard, true, playerLineLength);
			this.ball = factory.CreateBall(gameBoard);
			this.PlayerOne = factory.CreatePlayerName("You", true, gameBoard);
			this.PlayerTwo = factory.CreatePlayerName("Computer", false, gameBoard);
		}

		public void Run()
		{
			this.display.Clear();
			this.printingThread = new Thread(Print);
			this.ballMovementThread = new Thread(BallMovement);
			this.computerMovementThread = new Thread(ComputerMovement);
			this.printingThread.Start();
			this.ballMovementThread.Start();
			this.computerMovementThread.Start();

			this.PlayerMovement();
			this.NextGame();

		}
		private void BallMovement()
		{
			while (ball.CanMove)
			{
				this.ball.Move();
				Thread.Sleep(parameters.BallSpeed);
			}
		}
		private void PlayerMovement()
		{
			IKey key;
			while (ball.CanMove)
			{
				key = this.keyReader.ReadKey(true);

				if (key.IsDownArrow())
					this.player.Move(false);
				else if (key.IsUpArrow())
					this.player.Move(true);
				Thread.Sleep(30);
			}
		}
		private void NextGame()
		{
			if (ball.ExitSide)
				this.result.IncreaseLeft();
			else
				this.result.IncreaseRight();

			if (this.result.LeftResult == maxPossiblePoints)
				this.Winner = false; // false - player, true - computer
			else if (this.result.RightResult == maxPossiblePoints)
				this.Winner = true;
			else
			{
				Thread.Sleep(100);
				this.keyReader.ReadKey(true);
				this.gameBoard.Restart();
				this.player.Restart();
				this.computer.Restart();
				this.ball.Restart();
				this.Run();
			}
		}
		private void ComputerMovement()
		{
			Random rnd = new Random();

			while (ball.CanMove)
			{
				if (rnd.Next(1, 100) > this.parameters.Difficulty)
				{
					if (ball.Top > this.computer.Top + this.computer.Length / 2)
						this.computer.Move(true);
					else if (ball.Top < this.computer.Top + this.computer.Length / 2)
						this.computer.Move(false);
				}
				else
				{
					if (ball.Top > this.computer.Top + this.computer.Length / 2)
						computer.Move(false);
					else if (ball.Top < this.computer.Top + this.computer.Length / 2)
						computer.Move(true);
				}
				Thread.Sleep(45);
			}

		}
		private void Print()
		{
			Dictionary<char, string> symbolsToColor = new Dictionary<char, string>
			{
				{ '█', this.parameters.LineColor },
				{ '@', this.parameters.BallColor }
			};
			this.display.WriteBufferMatrixUntil(
				this.gameBoard.Matrix, 
				DEFAULT_COLOR, 
				symbolsToColor, 
				() => ball.CanMove);
		}


        public IGameBoard GameBoard{ get; }
        public IPlayerLine PlayerLine { get; }
        public IPlayerName PlayerName { get; }
        public IResult Result{ get; }
        public IBall Ball { get; }
    }
}