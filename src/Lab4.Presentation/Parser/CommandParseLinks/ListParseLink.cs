using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class ListParseLink : CommandBaseLink
{
    private readonly string _word = "list";
    private readonly FlagsParseLink _flagChain;

    public ListParseLink(FlagsParseLink flagChain)
    {
        _flagChain = flagChain;
    }

    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator)
    {
        if (iterator.Current == _word)
        {
            ICommandBuilder builder = new TreeListCommand.TreeListCommandBuilder();
            iterator.MoveNext();

            return _flagChain.Apply(iterator, builder);
        }

        return CallNext(iterator);
    }
}