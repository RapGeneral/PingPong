namespace PingPong.Core.BigText
{
	using System;
	using System.Text;
	using PingPong.Core.Contracts;
	using PingPong.Providers.Validation;

	public class BigWords : IBigWords
	{
        private const string SPACE_BETWEEN_BIG_WORDS = "Spaces between words cannot be negative!";
        private const string FONT_NULL = "The font cannot be null!";
        private const string WORDS_NULL = "Cannot create big words out of thin air...";

        public string[] MakeItBig(string words, IBigLetters font, int spacesBetweenWords = 4)
		{
			Validator.IfNull(font, FONT_NULL);
			Validator.IfNull(words, WORDS_NULL);
			spacesBetweenWords -= font.SpaceInBetween;
			Validator.IsNonNegative(spacesBetweenWords, SPACE_BETWEEN_BIG_WORDS);
			words = words.ToLower();
			string[] result = new string[font.LetterHeight];
			for (int i = 0; i < font.LetterHeight; i++)
			{
				StringBuilder line = new StringBuilder();
				for (int j = 0; j < words.Length; j++)
				{
					if (words[j] == ' ')
					{
						line.Append(new String(' ', spacesBetweenWords));
						continue;
					}
					line.Append(font.BigLetterLayer(words[j], i));
					if (j < words.Length - 1) line.Append(new string(' ', font.SpaceInBetween));
				}
				result[i] = line.ToString();
			}
			return result;
		}
	}
}

