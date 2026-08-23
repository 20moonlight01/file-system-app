using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class RenameParseLink : CommandBaseLink
{
    private readonly string _word = "rename";
    private readonly IParameterParseLink _parameterChain;

    public RenameParseLink(IParameterParseLink parameterChain)
    {
        _parameterChain = parameterChain;
    }

    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator)
    {
        if (iterator.Current == _word)
        {
            ICommandBuilder builder = new FileRenameCommand.FileRenameCommandBuilder();
            iterator.MoveNext();

            return _parameterChain.Apply(iterator, builder);
        }

        return CallNext(iterator);
    }
}