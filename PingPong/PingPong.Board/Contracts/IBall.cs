namespace PingPong.Board.Contracts
{
    public interface IBall : IObjectOnTheBoard, IRessetable
	{
        bool ExitSide { get; }
		bool CanMove { get; }
		void Move();
	}
}
