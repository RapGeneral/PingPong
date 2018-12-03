using PingPong.Core.Contracts;
using PingPong.Core.MenuCommands.Abstract;
using PingPong.Providers.Contracts;

namespace PingPong.Tests.Core.MenuCommands.Abstract.Mocks
{
	internal class CommandGameStartMock : GameEndScreen
	{
		public CommandGameStartMock(IMediumFont mediumFont, IBigWords bigWords, IDisplay display, IKeyReader keyReader)
			: base(mediumFont, bigWords, display, keyReader)
		{}
		public void EndMock(bool winner)
		{
			base.End(winner);
		}
	}
}
