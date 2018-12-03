namespace PingPong.Providers.Contracts
{
	public interface IDataWriter
	{
        /// <summary>
        /// Writes the coins in the db.
        /// </summary>
        /// <param name="coins"></param>
		void WriteCoins(int coins);
        /// <summary>
        /// Adds new item of a type to the db.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="type"></param>
		void AddNewItem(string item, string type);
	}
}
