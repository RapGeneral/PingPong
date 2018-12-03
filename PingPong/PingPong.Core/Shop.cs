namespace PingPong.Core
{
    using PingPong.Core.Contracts;
	using PingPong.Providers.Contracts;
	using PingPong.Providers.Validation;
	using System;
    public class Shop : IShop
    {
        private const int PRICE_COLOR = 100;
        private const string SHOP_ITEM_NULL = "Shop item cannot be null!";
        private const string SHOP_TYPE_NULL = "Shop type cannot be null!";
        private const string NEGATIVE_COINS = "Cannot set negative coins!";
		private const string COINS_ADDED_OUT_OF_RANGE = "Only positive amount of coins can be added!";
		private const string ERROR_MESSAGE_COLOR = "Red";
		private readonly IDataWriter dataWriter;
		private readonly IDisplay display;
		private readonly IKeyReader keyReader;

		private int coins;
        public Shop(IDisplay display, IKeyReader keyReader, IDataReader dataReader, IDataWriter dataWriter)
        {
			this.dataWriter = dataWriter;
			this.display = display;
			this.keyReader = keyReader;
			this.Coins = dataReader.TryReadCoins();
        }
        public int Coins
        {
			get => this.coins;
			set
			{
				Validator.IsNonNegative(value, NEGATIVE_COINS);
				this.coins = value;
			}
        }
        public void AddCoins(int amount)
        {
            Validator.IsNonNegative(amount, COINS_ADDED_OUT_OF_RANGE);
            Coins += amount;
        }
        public bool TryBuyItem(string item, string type)
        {
            Validator.IfNull(item, SHOP_ITEM_NULL);
            Validator.IfNull(type, SHOP_TYPE_NULL);
            this.display.Clear();
            this.display.WriteLine("Are you sure you want to purchace this item?");
			this.display.WriteLine("Y/N");
            while (true)
            {
                IKey key = this.keyReader.ReadKey();
                if (key.IsN())
                    return false;
                else if (key.IsY())
                {
                    if (Coins < PRICE_COLOR)
                    {
						this.display.Clear();
						this.display.ChangeForegroundColor(ERROR_MESSAGE_COLOR);
						this.display.WriteLine("You dont have enough money, grind more");
						this.display.ResetColor();
						this.display.WriteLine("Press a key to continue...");
                        this.keyReader.ReadKey(true);
                        return false;
                    }
                    this.Coins -= PRICE_COLOR;

					this.dataWriter.AddNewItem(item, type);
					this.dataWriter.WriteCoins(this.coins);
					return true;
                }
            }
        }
	}
}
