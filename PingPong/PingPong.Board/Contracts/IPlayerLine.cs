namespace PingPong.Board.Contracts
{
	public interface IPlayerLine : IObjectOnTheBoard, IRessetable
    {
		int Length { get; }
		void Move(bool direction);
	}
}
