using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParserFactories;

public class DisconnectCommandParserFactory : ICommandParserFactory
{
    public ICommandParseLink Create()
    {
        return new DisconnectCommandParseLink();
    }
}