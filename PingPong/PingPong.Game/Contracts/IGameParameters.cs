namespace PingPong.Game.Contracts
{
	public interface IGameParameters
	{
        /// <summary>
        /// The difficulty of a game. It is between 0 and 100, 
        /// representing the % on which the cpu will decide wether to take the right move or not.
        /// </summary>
		int Difficulty { get; set; }
		string LineColor { get; set; }
		string BallColor { get; set; }
        /// <summary>
        /// The speed of the ball. It is between 0 and 1000,
        /// representing the time between each of the ball's movements
        /// </summary>
		short BallSpeed { get; set; }
		short Left { get; set; }
		short Top { get; set; }
	}
}
