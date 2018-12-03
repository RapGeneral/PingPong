namespace PingPong.Core.Contracts
{
	public interface IChoice
	{
		/// <summary>
		/// The distance from the left side of the console
		/// </summary>
		int Left { get; }
		/// <summary>
		/// The distance from the top side of the console
		/// </summary>
		int Top { get; }
		/// <summary>
		/// The height of the choice object
		/// </summary>
		int Height { get; }
		/// <summary>
		/// Command holder holds the command and its params and executes them.
		/// </summary>
		ICommandHolder CommandHolder { get; }
		/// <summary>
		/// Prints the choice on its corresponding coordinates.
		/// </summary>
		void PrintChoice();
	}
}
