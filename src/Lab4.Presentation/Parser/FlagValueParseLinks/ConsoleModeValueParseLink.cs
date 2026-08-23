using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Utilities.OutputModes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagValueParseLinks;

public class ConsoleModeValueParseLink : FlagValueBaseLink
{
    private readonly string _name = "console";

    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator, ICommandBuilder builder)
    {
        if (!iterator.Peek())
            return new ParseResult.Failure();

        if (iterator.Current == _name
            && builder is FileShowCommand.FileShowCommandBuilder specificBuilder)
        {
            specificBuilder.WithMode(new ConsoleOutputMode());
            iterator.MoveNext();
            return new ParseResult.Success(specificBuilder);
        }

        if (builder is not FileShowCommand.FileShowCommandBuilder)
            return new ParseResult.Failure();

        iterator.MoveNext();

        return CallNext(iterator, builder);
    }
}