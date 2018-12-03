namespace PingPong.Providers.Contracts
{
	public interface IDisplayColor
	{
        /// <summary>
        /// Changes the bacground of the display to a color.
        /// </summary>
        /// <param name="color"></param>
		void ChangeBackgroundColor(string color);
        /// <summary>
        /// Changes the writting color of the display.
        /// </summary>
        /// <param name="color"></param>
		void ChangeForegroundColor(string color);
        /// <summary>
        /// Sets all of the color settings to default.
        /// </summary>
		void ResetColor();
	}
}
