namespace PingPong.Core.BigText
{
	using System;
	using PingPong.Core.Contracts;
	using PingPong.Providers.Validation;

	public class BigLetters5Tall : IMediumFont
	{
        private const string INVALID_BIG_TEXT_LAYER = "The layer is not valid!";
        private const string NOT_LETTER = "The given symbol is not a letter!";
        private readonly byte LETTER_HIGHT = 5;
		private readonly byte SPACE_BETWEEN = 2;
		//But its better just to not change it.
		public byte LetterHeight
		{
			get { return this.LETTER_HIGHT; }
		}
		public byte SpaceInBetween
		{
			get { return this.SPACE_BETWEEN; }
		}

		private readonly string[] A = new string[]{
										" ██ ",
										"█  █",
										"████",
										"█  █",
										"█  █"};

		private readonly string[] B = new string[]{
										"███ ",
										"█  █",
										"████",
										"█  █",
										"███ "};

		private readonly string[] C = new string[] {
										"███",
										"█  ",
										"█  ",
										"█  ",
										"███"};

		private readonly string[] D = new string[]{
										 "███ ",
										 "█  █",
										 "█  █",
										 "█  █",
										 "███ "};

		private readonly string[] E = new string[] {
										 "███",
										 "█  ",
										 "███",
										 "█  ",
										 "███"};

		private readonly string[] H = new string[] {
										 "█  █",
										 "█  █",
										 "████",
										 "█  █",
										 "█  █"};

		private readonly string[] I = new string[] {
										 "█",
										 " ",
										 "█",
										 "█",
										 "█"};

		private readonly string[] K = new string[] {
										 "█  █",
										 "█ █ ",
										 "██  ",
										 "█ █ ",
										 "█  █"};

		private readonly string[] L = new string[] {
										 "█  ",
										 "█  ",
										 "█  ",
										 "█  ",
										 "███"};

		private readonly string[] M = new string[] {
										 "█   █",
										 "██ ██",
										 "█ █ █",
										 "█   █",
										 "█   █"};

		private readonly string[] N = new string[] {
										 "█   █",
										 "██  █",
										 "█ █ █",
										 "█  ██",
										 "█   █"};

		private readonly string[] O = new string[] {
										 " ██ ",
										 "█  █",
										 "█  █",
										 "█  █",
										 " ██ "};

		private readonly string[] P = new string[] {
										  "████",
										  "█  █",
										  "████",
										  "█   ",
										  "█   "};

		private readonly string[] R = new string[] {
										  "████",
										  "█  █",
										  "████",
										  "█ █ ",
										  "█  █"};

		private readonly string[] S = new string[] {
										  "███",
										  "█  ",
										  "███",
										  "  █",
										  "███"};

		private readonly string[] T = new string[] {
										  "█████",
										  "  █  ",
										  "  █  ",
										  "  █  ",
										  "  █  "};

		private readonly string[] U = new string[] {
										  "█  █",
										  "█  █",
										  "█  █",
										  "█  █",
										  " ██ "};

        private readonly string[] W = new string[] {
                                          "█     █",
                                          " █   █ ",
                                          " █ █ █ ",
                                          "  █ █  ",
                                          "  █ █  "};

        private readonly string[] X = new string[] {
										  "█   █",
										  " █ █ ",
										  "  █  ",
										  " █ █ ",
										  "█   █"};

		private readonly string[] Y = new string[] {
										  "█   █",
										  "█   █",
										  " █ █ ",
										  "  █  ",
										  "  █  "};

		public string BigLetterLayer(char letter, int layer)
		{
			Validator.IsLetter(letter, NOT_LETTER);
			Validator.IfIsInRangeInclusive(layer, 0, this.LETTER_HIGHT, INVALID_BIG_TEXT_LAYER);
			switch (Char.ToLower(letter))
			{
				case 'a':
					return A[layer];
				case 'b':
					return B[layer];
				case 'c':
					return C[layer];
				case 'd':
					return D[layer];
				case 'e':
					return E[layer];
				case 'h':
					return H[layer];
				case 'i':
					return I[layer];
				case 'k':
					return K[layer];
				case 'l':
					return L[layer];
				case 'm':
					return M[layer];
				case 'n':
					return N[layer];
				case 'o':
					return O[layer];
				case 'p':
					return P[layer];
				case 'r':
					return R[layer];
				case 's':
					return S[layer];
				case 't':
					return T[layer];
				case 'u':
					return U[layer];
                case 'w':
                    return W[layer];
				case 'x':
					return X[layer];
				case 'y':
					return Y[layer];
			}
			throw new NotImplementedException("Letter not implemented!");
		}
	}
}  