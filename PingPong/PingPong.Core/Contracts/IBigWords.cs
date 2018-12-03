namespace PingPong.Core.Contracts
{
	public interface IBigWords
	{
		/// <summary>
		/// Given a sentence, a font and a space between two words reformats it and returns it (bigger)
		/// </summary>
		/// <param name="words"></param>
		/// <param name="font"></param>
		/// <param name="spacesBetweenWords"></param>
		/// <returns></returns>
		string[] MakeItBig(string words, IBigLetters font, int spacesBetweenWords = 4);
	}
}
