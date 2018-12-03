using System;
using System.Collections.Generic;
using System.Text;

namespace PingPong.Board.Contracts
{
    public interface IMeteorShower : IObjectOnTheBoard
    {
        void MoveMeteorites();
    }
}
