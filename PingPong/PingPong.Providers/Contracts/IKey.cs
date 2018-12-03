namespace PingPong.Providers.Contracts
{
	public interface IKey
	{
		bool IsRightArrow();
		bool IsLeftArrow();
		bool IsUpArrow();
		bool IsDownArrow();
		bool IsEnter();
		bool IsN();
		bool IsY();
	}
}
