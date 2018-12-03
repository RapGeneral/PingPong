namespace PingPong.Core.Contracts
{
	public interface IMenu
	{
		/// <summary>
		/// Waits until the user selects a choice and runs it.
		/// </summary>
		void RunChoice();
		/// <summary>
		/// Prints the menu
		/// </summary>
		void Print();
	}
}
