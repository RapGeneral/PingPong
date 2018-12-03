namespace PingPong.Board.Contracts
{
	public interface IResult : IObjectOnTheBoard
    {

		int LeftResult { get; }
		int RightResult { get; }
		void IncreaseLeft();
		void IncreaseRight();

    }
}
