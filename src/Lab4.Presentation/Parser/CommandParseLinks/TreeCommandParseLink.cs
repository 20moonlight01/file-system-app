namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class TreeCommandParseLink : CommandStartBaseLink
{
    private const string Word = "tree";

    public TreeCommandParseLink(ICommandParseLink? nextChain) : base(Word, nextChain) { }
}