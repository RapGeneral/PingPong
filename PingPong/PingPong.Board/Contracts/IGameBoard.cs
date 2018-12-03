namespace PingPong.Board.Contracts
{
    public interface IGameBoard : IRessetable
    {
        char[,] Matrix{ get; set; }
    }
}
