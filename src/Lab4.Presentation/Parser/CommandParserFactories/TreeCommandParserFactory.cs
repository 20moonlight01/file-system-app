using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagValueParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParserFactories;

public class TreeCommandParserFactory : ICommandParserFactory
{
    public ICommandParseLink Create()
    {
        return new TreeCommandParseLink(
            new GotoParseLink(
                    new GotoPathParseLink()
                        .AddNext(new ParameterTerminalLink()))
                .AddNext(new ListParseLink(
                    FlagsParseLink.Builder
                        .AddFlagToParse("-d", new DepthValueParseLink()
                            .AddNext(new TerminalFlagValueLink()))
                        .Build())));
    }
}