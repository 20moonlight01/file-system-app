using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

public class ShowPathParseLink : ParameterBaseLink
{
    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator, ICommandBuilder builder)
    {
        if (!iterator.Peek())
            return new ParseResult.Failure();

        if (builder is FileShowCommand.FileShowCommandBuilder specificBuilder)
        {
            specificBuilder.WithPath(iterator.Current);
            iterator.MoveNext();
            return CallNext(iterator, specificBuilder);
        }

        return new ParseResult.Failure();
    }
}