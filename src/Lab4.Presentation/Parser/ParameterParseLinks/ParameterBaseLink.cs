using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

public abstract class ParameterBaseLink : IParameterParseLink
{
    private IParameterParseLink? _next;

    public abstract ParseResult Apply(ConsoleParser.ArgumentsIterator iterator, ICommandBuilder builder);

    public IParameterParseLink AddNext(IParameterParseLink link)
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

    protected ParseResult CallNext(ConsoleParser.ArgumentsIterator iterator, ICommandBuilder builder)
    {
        return _next?.Apply(iterator, builder)
               ?? new ParseResult.Failure();
    }
}