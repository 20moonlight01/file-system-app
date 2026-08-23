namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class FileCommandParseLink : CommandStartBaseLink
{
    private const string Word = "file";

    public FileCommandParseLink(ICommandParseLink? nextChain) : base(Word, nextChain) { }
}