using PingPong.Board.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PingPong.Board
{
    public class MeteorShower : ObjectOnTheBoard, IMeteorShower
    {
      
        private int moveTop;
        private int moveLeft;
        private const int distanceLeft = 5;
        private const int distanceForMiddleRow = 3;
        private const int distanceTop = 1;

        public MeteorShower(IGameBoard gameBoard) 
			: base(gameBoard)
        {
            this.Top = 2;
            this.Left = gameBoard.Matrix.GetLength(1) / 3;

        }

        public void MoveMeteorites()
        {
            Thread.Sleep(250);
            moveLeft++;
            moveTop++;
            gameBoard.Matrix[Top, Left] = ' ';
            gameBoard.Matrix[Top, Left + distanceLeft] = ' ';
            gameBoard.Matrix[Top, Left + (2 * distanceLeft)] = ' ';
            gameBoard.Matrix[Top + distanceTop, Left + distanceForMiddleRow] = ' ';
            gameBoard.Matrix[Top + distanceTop, Left + distanceForMiddleRow + distanceLeft] = ' ';
            gameBoard.Matrix[Top + distanceTop, Left + distanceForMiddleRow + (distanceLeft * 2)] = ' ';
            gameBoard.Matrix[Top + 2 * distanceTop, Left] = ' ';
            gameBoard.Matrix[Top + 2 * distanceTop, Left + distanceLeft] = ' ';
            gameBoard.Matrix[Top + 2 * distanceTop, Left + (2 * distanceLeft)] =' ';
            this.Top += moveTop;
            this.Left += moveLeft;
            if (this.Top >= Console.BufferHeight)
            {
                moveLeft = 0;
                moveTop = 0;
                Top = 2;
                Left = gameBoard.Matrix.GetLength(1) / 3;
            }
            gameBoard.Matrix[Top, Left] = '*';
            gameBoard.Matrix[Top, Left + distanceLeft] = '*';
            gameBoard.Matrix[Top, Left + (2 * distanceLeft)] = '*';
            gameBoard.Matrix[Top + distanceTop, Left + distanceForMiddleRow] = '*';
            gameBoard.Matrix[Top + distanceTop, Left + distanceForMiddleRow + distanceLeft] = '*';
            gameBoard.Matrix[Top + distanceTop, Left + distanceForMiddleRow + (distanceLeft * 2)] = '*';
            gameBoard.Matrix[Top + 2 * distanceTop, Left] = '*';
            gameBoard.Matrix[Top + 2 * distanceTop, Left + distanceLeft] = '*';
            gameBoard.Matrix[Top + 2 * distanceTop, Left + (2 * distanceLeft)] = '*';

        }

    }
}
