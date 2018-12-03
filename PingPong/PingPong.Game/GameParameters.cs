using PingPong.Game.Contracts;
using PingPong.Providers.Validation;

namespace PingPong.Game
{
	public class GameParameters : IGameParameters
    {
		private const string DEFAULT_COLOR = "White";
		private const short DEFAULT_BALL_SPEED = 60;
		private const int DEFAULT_DIFICULTY = 40;
		private const short DEFAULT_WIDTH = 80;
		private const short DEFAULT_HEIGHT = 30;

		private int difficulty = DEFAULT_DIFICULTY;
		private string lineColor = DEFAULT_COLOR;
		private string ballColor = DEFAULT_COLOR;
		private short ballSpeed = DEFAULT_BALL_SPEED;
		private short left = DEFAULT_WIDTH;
		private short top = DEFAULT_HEIGHT;

		public int Difficulty
		{
			get { return this.difficulty; }
			set
            {
                Validator.IfIsInRangeInclusive(value, 0, 100, "Difficulty should be between 0 and 100!");
                this.difficulty = value;
            }
		}
		public string LineColor
        {
			get { return this.lineColor; }
			set
            {
                Validator.IfNull(value, "Line color cannot be null!");
                this.lineColor = value;
            }
		}
		public short BallSpeed
		{
			get { return this.ballSpeed; }
			set
            {
                Validator.IfIsInRangeInclusive(value, 0, 1000, "Ball speed cannot be negative or more than 1000!");
                this.ballSpeed = value;
            }
		}
		public string BallColor
		{
			get { return this.ballColor; }
			set
            {
                Validator.IfNull(value, "Ball color cannot be null!");
                this.ballColor = value;
            }
		}
		public short Left
		{
			get { return this.left; }
			set
            {
                Validator.IfIsInRangeInclusive(value, 0, 120, "Width cannot be negative or more than 120!");
                this.left = value;
            }
		}
		public short Top
		{
			get { return this.top; }
			set
            {
                Validator.IfIsInRangeInclusive(value, 0, 45, "Height cannot be negative or more than 45!");
                this.top = value;
            }
		}
	}
}
