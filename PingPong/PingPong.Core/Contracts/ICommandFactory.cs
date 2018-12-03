using System.Collections.Generic;
namespace PingPong.Core.Contracts
{
	public interface ICommandFactory
	{
		/// <summary>
		/// Returns command holder, containing:
		///  registered command, based on its name, or the enum it belongs to;
		///  and its parameters.
		/// </summary>
		/// <param name="enumItem"></param>
		/// <param name="enumType"></param>
		/// <returns></returns>
		ICommandHolder CreateCommand(string enumItem, string enumType);
		/// <summary>
		/// Returns list of command holders, containing a command, registered command, 
		/// based on its name, or the enum it belongs to; and its parameters.
		/// </summary>
		/// <param name="enumItems"></param>
		/// <param name="enumType"></param>
		/// <returns></returns>
		IList<ICommandHolder> CreateCommands(string[] enumItems, string enumType);
	}
}
