namespace PingPong.Providers.Contracts
{
	public interface IDisplaySize
	{
        /// <summary>
        /// Changes the size of the buffer.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
		void ChangeBufferSize(int x, int y);
		int WindowWidth { get; set; }
		int WindowHeight { get; set; }
		int BufferHeight { get; set; }
        /// <summary>
        /// Changes the size of the window.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
		void ChangeSize(int x, int y);
	}
}
