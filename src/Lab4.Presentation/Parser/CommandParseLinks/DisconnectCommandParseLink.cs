using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class DisconnectCommandParseLink : CommandBaseLink
{
    private readonly string _word = "disconnect";

    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator)
    {
        if (iterator.Current == _word)
        {
            iterator.MoveNext();
            return new ParseResult.Success(new DisconnectCommand.DisconnectCommandBuilder());
        }

        return CallNext(iterator);
    }
}