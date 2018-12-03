namespace PingPong.Core.Contracts
{
	public interface IBigLetters
	{
		/// <summary>
		/// Returns a layer of a big letter's content. (if exists)
		/// </summary>
		/// <param name="letter"></param>
		/// <param name="layer"></param>
		/// <returns></returns>
		string BigLetterLayer(char letter, int layer);
		/// <summary>
		/// Returns the height of the letters.
		/// </summary>
		byte LetterHeight {get; }
		/// <summary>
		/// The space between two characters in a word.
		/// </summary>
		byte SpaceInBetween {get; }
	}
}
