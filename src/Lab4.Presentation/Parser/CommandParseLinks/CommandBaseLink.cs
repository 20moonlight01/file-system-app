namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public abstract class CommandBaseLink : ICommandParseLink
{
    private ICommandParseLink? _next;

    public abstract ParseResult Apply(ConsoleParser.ArgumentsIterator iterator);

    public ICommandParseLink AddNext(ICommandParseLink link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    protected ParseResult CallNext(ConsoleParser.ArgumentsIterator iterator)
    {
        return _next?.Apply(iterator)
               ?? new ParseResult.Failure();
    }
}