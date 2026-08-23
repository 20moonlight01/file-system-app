using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagValueParseLinks;

public class LocalModeValueParseLink : FlagValueBaseLink
{
    private readonly string _name = "local";

    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator, ICommandBuilder builder)
    {
        if (!iterator.Peek())
            return new ParseResult.Failure();

        if (iterator.Current == _name
            && builder is ConnectCommand.ConnectCommandBuilder specificBuilder)
        {
            specificBuilder.WithMode(new LocalFileSystemMode());
            iterator.MoveNext();
            return new ParseResult.Success(specificBuilder);
        }

        if (builder is not ConnectCommand.ConnectCommandBuilder)
            return new ParseResult.Failure();

        iterator.MoveNext();

        return CallNext(iterator, builder);
    }
}