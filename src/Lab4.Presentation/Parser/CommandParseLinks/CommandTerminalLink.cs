namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class CommandTerminalLink : CommandBaseLink
{
    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator)
    {
        return new ParseResult.Failure();
    }
}