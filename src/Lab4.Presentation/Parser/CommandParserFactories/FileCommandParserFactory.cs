using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagValueParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParserFactories;

public class FileCommandParserFactory : ICommandParserFactory
{
    public ICommandParseLink Create()
    {
        return new FileCommandParseLink(
            new CopyParseLink(
                    new CopySourcePathLink()
                        .AddNext(new CopyDestinationPathLink())
                        .AddNext(new ParameterTerminalLink()))
                .AddNext(new DeleteParseLink(
                    new DeletePathParseLink()
                        .AddNext(new ParameterTerminalLink())))
                .AddNext(new MoveParseLink(
                    new MoveSourcePathLink()
                        .AddNext(new MoveDestinationPathLink())
                        .AddNext(new ParameterTerminalLink())))
                .AddNext(new RenameParseLink(
                    new RenamePathParseLink()
                        .AddNext(new RenameNameParseLink())
                        .AddNext(new ParameterTerminalLink())))
                .AddNext(new ShowParseLink(
                    new ShowPathParseLink()
                        .AddNext(new ParameterTerminalLink()),
                    FlagsParseLink.Builder
                        .AddFlagToParse("-m", new ConsoleModeValueParseLink()
                            .AddNext(new TerminalFlagValueLink()))
                        .Build())));
    }
}