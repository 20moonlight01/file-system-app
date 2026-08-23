using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class DeleteParseLink : CommandBaseLink
{
    private readonly string _word = "delete";
    private readonly IParameterParseLink _parameterChain;

    public DeleteParseLink(IParameterParseLink parameterChain)
    {
        _parameterChain = parameterChain;
    }

    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator)
    {
        if (iterator.Current == _word)
        {
            ICommandBuilder builder = new FileDeleteCommand.FileDeleteCommandBuilder();
            iterator.MoveNext();

            return _parameterChain.Apply(iterator, builder);
        }

        return CallNext(iterator);
    }
}