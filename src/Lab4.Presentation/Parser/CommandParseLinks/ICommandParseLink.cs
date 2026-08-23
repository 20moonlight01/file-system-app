namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public interface ICommandParseLink
{
    ParseResult Apply(ConsoleParser.ArgumentsIterator iterator);

    ICommandParseLink AddNext(ICommandParseLink link);
}