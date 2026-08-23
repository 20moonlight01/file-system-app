using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

public interface IParameterParseLink
{
    ParseResult Apply(ConsoleParser.ArgumentsIterator iterator, ICommandBuilder builder);

    IParameterParseLink AddNext(IParameterParseLink link);
}