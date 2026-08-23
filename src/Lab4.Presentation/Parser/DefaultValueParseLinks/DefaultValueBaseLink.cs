using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.DefaultValueParseLinks;

public abstract class DefaultValueBaseLink : IDefaultValueParseLink
{
    private IDefaultValueParseLink? _next;

    public abstract ParseResult Apply(ICommandBuilder builder);

    public IDefaultValueParseLink AddNext(IDefaultValueParseLink link)
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

    protected ParseResult CallNext(ICommandBuilder builder)
    {
        return _next?.Apply(builder)
               ?? new ParseResult.Failure();
    }
}