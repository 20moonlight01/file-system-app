using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.DefaultValueParseLinks;

public class DefaultValueTerminalLink : DefaultValueBaseLink
{
    public override ParseResult Apply(ICommandBuilder builder)
    {
        return new ParseResult.Success(builder);
    }
}