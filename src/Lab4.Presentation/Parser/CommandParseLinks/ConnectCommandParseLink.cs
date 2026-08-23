using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.DefaultValueParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public class ConnectCommandParseLink : CommandBaseLink
{
    private readonly string _word = "connect";
    private readonly IParameterParseLink _parameterChain;
    private readonly IDefaultValueParseLink _defaultValueChain;
    private readonly FlagsParseLink _flagChain;

    public ConnectCommandParseLink(
        IParameterParseLink parameterChain,
        IDefaultValueParseLink defaultValueChain,
        FlagsParseLink flagChain)
    {
        _parameterChain = parameterChain;
        _defaultValueChain = defaultValueChain;
        _flagChain = flagChain;
    }

    public override ParseResult Apply(ConsoleParser.ArgumentsIterator iterator)
    {
        if (iterator.Current == _word)
        {
            ICommandBuilder builder = new ConnectCommand.ConnectCommandBuilder();
            iterator.MoveNext();

            ParseResult parameters = _parameterChain.Apply(iterator, builder);
            if (parameters is ParseResult.Success success)
            {
                ParseResult defaultValues = _defaultValueChain.Apply(success.CommandBuilder);
                if (defaultValues is ParseResult.Success defaultValuesSuccess)
                    return _flagChain.Apply(iterator, defaultValuesSuccess.CommandBuilder);
            }

            return new ParseResult.Failure();
        }

        return CallNext(iterator);
    }
}