namespace PingPong.Providers.Contracts
{
	public interface IDataReader
	{
        /// <summary>
        /// Checks if an item of a type exists in the db.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="type"></param>
        /// <returns></returns>
		bool CheckIfItemExists(string item, string type);
        /// <summary>
        /// Tries to read the coins in the db.
        /// </summary>
        /// <returns></returns>
		int TryReadCoins();
	}
}
