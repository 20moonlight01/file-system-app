using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParserFactories;

public interface ICommandParserFactory
{
    ICommandParseLink Create();
}