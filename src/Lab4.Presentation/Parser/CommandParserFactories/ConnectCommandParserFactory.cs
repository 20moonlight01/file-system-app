using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.DefaultValueParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagValueParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParserFactories;

public class ConnectCommandParserFactory : ICommandParserFactory
{
    public ICommandParseLink Create()
    {
        return new ConnectCommandParseLink(
            new ConnectAddressParseLink()
                .AddNext(new ParameterTerminalLink()),
            new DefaultFileSystemModeLink()
                .AddNext(new DefaultValueTerminalLink()),
            FlagsParseLink.Builder
                .AddFlagToParse("-m", new LocalModeValueParseLink()
                    .AddNext(new TerminalFlagValueLink()))
                .Build());
    }
}