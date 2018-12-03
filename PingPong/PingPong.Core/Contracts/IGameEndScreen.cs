namespace PingPong.Core.Contracts
{
    public interface IGameEndScreen
    {
        /// <summary>
        /// Displays win/loose screen.
        /// </summary>
        /// <param name="winner"></param>
        void End(bool winner);
    }
}
