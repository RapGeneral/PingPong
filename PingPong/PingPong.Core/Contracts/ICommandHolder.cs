namespace PingPong.Core.Contracts
{
	public interface ICommandHolder
	{
		/// <summary>
		/// Runs the command it holds with the parameters it holds.
		/// </summary>
		void Execute();
		/// <summary>
		/// The enum, to which the command belongs.
		/// </summary>
		string EnumType { get; }
		/// <summary>
		/// The name of the command.
		/// </summary>
		string EnumItem { get; }
	}
}
