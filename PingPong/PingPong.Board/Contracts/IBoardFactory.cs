using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.Board.Contracts
{
    public interface IBoardFactory
    {
        IGameBoard CreateBoard(short top, short left);
        IResult CreateResult(IGameBoard gameBoard);
        IPlayerLine CreatePlayerLine(IGameBoard gameBoard, bool playerSide, int playerLineLength);
        IBall CreateBall(IGameBoard gameBoard);
        IPlayerName CreatePlayerName(string name, bool nameSide, IGameBoard gameBoard);
        
    }
}
