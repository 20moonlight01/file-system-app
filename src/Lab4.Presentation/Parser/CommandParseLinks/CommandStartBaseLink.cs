namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public abstract class CommandStartBaseLink : ICommandParseLink
{
    private readonly string _word;
    private readonly ICommandParseLink? _nextChain;
    private ICommandParseLink? _next;

    protected CommandStartBaseLink(string word, ICommandParseLink? nextChain)
    {
        _word = word;
        _nextChain = nextChain;
    }

    public ParseResult Apply(ConsoleParser.ArgumentsIterator iterator)
    {
        if (_nextChain is null)
            return new ParseResult.Failure();

        if (iterator.Current == _word)
        {
            iterator.MoveNext();
            return _nextChain.Apply(iterator);
        }

        return CallNext(iterator);
    }

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

    private ParseResult CallNext(ConsoleParser.ArgumentsIterator iterator)
    {
        return _next?.Apply(iterator)
               ?? new ParseResult.Failure();
    }
}