namespace PingPong.Providers.Contracts
{
	public interface IKeyReader
	{
        /// <summary>
        /// Reads a key from an input. You can specify whether the character will display or not.
        /// </summary>
        /// <param name="intercept"></param>
        /// <returns></returns>
		IKey ReadKey(bool intercept = false);
	}
}
