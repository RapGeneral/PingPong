using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.Core.Contracts
{
    public interface IShop
    {
		/// <summary>
		/// Gets the current amount of coins.
		/// </summary>
        int Coins { get; }
		/// <summary>
		/// Adds coins.
		/// </summary>
		/// <param name="amount"></param>
        void AddCoins(int amount);
		/// <summary>
		/// Asks the user for confirmation and buys and item if there are enough coins.
		/// </summary>
		/// <param name="item"></param>
		/// <param name="type"></param>
		/// <returns></returns>
        bool TryBuyItem(string item, string type);
    }
}
