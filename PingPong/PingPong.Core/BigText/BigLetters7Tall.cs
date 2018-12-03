namespace PingPong.Core.BigText
{
	using System;
	using PingPong.Core.Contracts;
	using PingPong.Providers.Validation;

	public class BigLetters7Tall : IBigFont
    {

        private const string INVALID_BIG_TEXT_LAYER = "The layer is not valid!";
        private const string NOT_LETTER = "The given symbol is not a letter!";
        private readonly byte LETTER_HEIGHT = 7;
		private readonly byte SPACE_BETWEEN = 3;
		//But its better just to not change it.
		public byte LetterHeight
		{
			get { return this.LETTER_HEIGHT; }
		}
		public byte SpaceInBetween
		{
			get { return this.SPACE_BETWEEN; }
		}

		private readonly string[] G = new string[] {
										 "   ██████   ",
										 " ██      ██ ",
										 "██          ",
										 "██    ████  ",
										 "██        ██",
										 " ██      ██ ",
										 "   ██████   "};

		private readonly string[] H = new string[] {
										"██     ██",
										"██     ██",
										"██     ██",
										"█████████",
										"██     ██",
										"██     ██",
										"██     ██"};

		private readonly string[] I = new string[] {
										 "██",
										 "  ",
										 "██",
										 "██",
										 "██",
										 "██",
										 "██"};

		private readonly string[] N = new string[] {
										 "███      ██",
										 "██ █     ██",
										 "██  █    ██",
										 "██   █   ██",
										 "██    █  ██",
										 "██     █ ██",
										 "██      ███"};

		private readonly string[] O = new string[] {
										 "   █████   ",
										 " ██     ██ ",
										 "██       ██",
										 "██       ██",
										 "██       ██",
										 " ██     ██ ",
										 "   █████   "};

		private readonly string[] P = new string[] {
										 "█████████",
										 "██     ██",
										 "██     ██",
										 "█████████",
										 "██       ",
										 "██       ",
										 "██       "};

		private readonly string[] S = new string[] {
										 "█████████",
										 "██       ",
										 "██       ",
										 "█████████",
										 "       ██",
										 "       ██",
										 "█████████"};

		public string BigLetterLayer(char letter, int layer)
		{
			Validator.IsLetter(letter, NOT_LETTER);
			Validator.IfIsInRangeInclusive(layer, 0, this.LetterHeight, INVALID_BIG_TEXT_LAYER);
			switch (Char.ToLower(letter))
			{
				case 'g':
					return G[layer];
				case 'h':
					return H[layer];
				case 'i':
					return I[layer];
				case 'n':
					return N[layer];
				case 'o':
					return O[layer];
				case 'p':
					return P[layer];
				case 's':
					return S[layer];
			}
			throw new NotImplementedException("Letter not implemented!");
		}
	}
}
