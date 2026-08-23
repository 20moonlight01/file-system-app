using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class GotoParseLink : CommandBaseLink
{
    private readonly string _word = "goto";
    private readonly IParameterParseLink _parameterChain;

    public GotoParseLink(IParameterParseLink parameterChain)
    {
        _parameterChain = parameterChain;
    }

    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator)
    {
        if (iterator.Current == _word)
        {
            ICommandBuilder builder = new TreeGotoCommand.TreeGotoCommandBuilder();
            iterator.MoveNext();

            return _parameterChain.Apply(iterator, builder);
        }

        return CallNext(iterator);
    }
}