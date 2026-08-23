using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class MoveParseLink : CommandBaseLink
{
    private readonly string _word = "move";
    private readonly IParameterParseLink _parameterChain;

    public MoveParseLink(IParameterParseLink parameterChain)
    {
        _parameterChain = parameterChain;
    }

    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator)
    {
        if (iterator.Current == _word)
        {
            ICommandBuilder builder = new FileMoveCommand.FileMoveCommandBuilder();
            iterator.MoveNext();

            return _parameterChain.Apply(iterator, builder);
        }

        return CallNext(iterator);
    }
}