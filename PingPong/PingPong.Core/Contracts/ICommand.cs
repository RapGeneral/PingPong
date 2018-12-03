namespace PingPong.Core.Contracts
{
	public interface ICommand
    {
		/// <summary>
		/// Executes the command via parameters.
		/// </summary>
		/// <param name="enumItem"></param>
		/// <param name="enumType"></param>
		void Execute(string enumItem, string enumType);
    }
}
