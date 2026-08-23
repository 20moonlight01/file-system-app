using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagValueParseLinks;

public interface IFlagValueParseLink
{
    ParseResult Apply(ConsoleParser.ArgumentsIterator iterator, ICommandBuilder builder);

    IFlagValueParseLink AddNext(IFlagValueParseLink link);
}