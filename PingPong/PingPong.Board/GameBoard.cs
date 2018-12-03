using PingPong.Board.Contracts;
using PingPong.Providers.Validation;

namespace PingPong.Board
{
    public class GameBoard : IGameBoard
    {
		private const string NULL_GAMEBOARD = "Game matrix cannot be null";
        private char[,] matrix;
        public GameBoard(int top, int left)
        {
            this.Matrix = new char[top, left];

			//setting the walls
			for (int i = 0; i < left; i++)
            {
                matrix[1, i] = '=';
                matrix[top - 3, i] = '=';
            }
        }
		public void Restart()
		{
			for (int i = 2; i < this.Matrix.GetLength(0) - 3; i++)
			{
				this.Matrix[i, 0] = ' ';
				this.Matrix[i, this.Matrix.GetLength(1) - 1] = ' ';
			}
		}
        public char[,] Matrix
        {
            get
            {
                return this.matrix;
            }
            set
            {
				Validator.IfNull(value, NULL_GAMEBOARD);
				matrix = value;
            }
            
        }
    }
}
