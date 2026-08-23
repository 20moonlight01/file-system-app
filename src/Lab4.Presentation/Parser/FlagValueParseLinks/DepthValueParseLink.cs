using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagValueParseLinks;

public class DepthValueParseLink : FlagValueBaseLink
{
    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator, ICommandBuilder builder)
    {
        if (!iterator.Peek())
            return new ParseResult.Failure();

        if (builder is TreeListCommand.TreeListCommandBuilder specificBuilder)
        {
            int depth;
            if (!int.TryParse(iterator.Current, out depth))
                return new ParseResult.Failure();

            specificBuilder.WithDepth(depth);
            iterator.MoveNext();
            return new ParseResult.Success(specificBuilder);
        }

        if (builder is not TreeListCommand.TreeListCommandBuilder)
            return new ParseResult.Failure();

        iterator.MoveNext();

        return CallNext(iterator, builder);
    }
}