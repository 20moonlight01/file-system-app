using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class ShowParseLink : CommandBaseLink
{
    private readonly string _word = "show";
    private readonly IParameterParseLink _parameterChain;
    private readonly FlagsParseLink _flagChain;

    public ShowParseLink(
        IParameterParseLink parameterChain,
        FlagsParseLink flagChain)
    {
        _parameterChain = parameterChain;
        _flagChain = flagChain;
    }

    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator)
    {
        if (iterator.Current == _word)
        {
            ICommandBuilder builder = new FileShowCommand.FileShowCommandBuilder();
            iterator.MoveNext();

            ParseResult parameters = _parameterChain.Apply(iterator, builder);
            if (parameters is ParseResult.Success success)
                return _flagChain.Apply(iterator, success.CommandBuilder);

            return new ParseResult.Failure();
        }

        return CallNext(iterator);
    }
}