namespace PingPong.Core.Contracts
{
	public interface IChoiceFactory
	{
		/// <summary>
		/// Returns a menu choice and injects all of the additional dependencies.
		/// </summary>
		/// <param name="top"></param>
		/// <param name="nameToPrint"></param>
		/// <param name="commandHolder"></param>
		/// <returns></returns>
		IChoice CreateaMenuChoice(int top, string[] nameToPrint, ICommandHolder commandHolder);
		/// <summary>
		/// Returns a menu choice and injects all of the additional dependencies.
		/// </summary>
		/// <param name="top"></param>
		/// <param name="left"></param>
		/// <param name="commandHolder"></param>
		/// <returns></returns>
		IChoice CreateaShopChoice(int top, int left, ICommandHolder commandHolder);
	}
}
