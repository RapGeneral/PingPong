using PingPong.Board.Contracts;

namespace PingPong.Board.Factories
{
    public class BoardFactory : IBoardFactory
    {
        public IBall CreateBall(IGameBoard gameBoard)
        {
            return new Ball(gameBoard);
        }

        public IGameBoard CreateBoard(short top, short left)
        {
            return new GameBoard(top, left);
        }

        public IResult CreateResult(IGameBoard gameBoard)
        {
            return new Result(gameBoard);
        }
        public IPlayerLine CreatePlayerLine(IGameBoard gameBoard, bool playerSide, int playerLineLength)
        {
            return new PlayerLine(gameBoard, playerSide, playerLineLength);
        }

        public IPlayerName CreatePlayerName(string name, bool nameSide, IGameBoard gameBoard)
        {
            return new PlayerName(name, nameSide, gameBoard);
        }
    }
}
