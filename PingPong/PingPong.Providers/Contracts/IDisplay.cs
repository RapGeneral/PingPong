namespace PingPong.Providers.Contracts
{
	public interface IDisplay : IDisplayWritable, IDisplaySize, IDisplayColor
	{
        /// <summary>
        /// Sets the encoding of the output to UTF8.
        /// </summary>
		void SetOutputEncodingToUTF8();
        /// <summary>
        /// Toggles the cursor between visible/invisible
        /// </summary>
		bool CursorVisible { get; set; }
	}
}
