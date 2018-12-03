using System;

namespace PingPong.Core.Contracts
{
    public interface ICommandParser
    {
        (bool, object) TryParseCommand(string commandName, Type type);
    }
}
