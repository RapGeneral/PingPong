namespace PingPong.Core.MenuCommands
{
    using PingPong.Core.Contracts;
	using PingPong.Game.Contracts;
	using PingPong.Providers.Contracts;

    public class CommandBallColors : ICommand
    {
		private readonly IGameParameters parameters;
        private readonly IShop shop;
		private readonly IDataReader dataReader;

		public CommandBallColors(IGameParameters parameters, IShop shop, IDataReader dataReader)
		{
			this.parameters = parameters;
            this.shop = shop;
			this.dataReader = dataReader;
		}
		public void Execute(string enumItem, string enumType)
		{
			if(dataReader.CheckIfItemExists(enumItem, enumType))
			{
				parameters.BallColor = enumItem;
				return;
			}
            if(shop.TryBuyItem(enumItem, enumType))
				parameters.BallColor = enumItem;
        }
    }
}
