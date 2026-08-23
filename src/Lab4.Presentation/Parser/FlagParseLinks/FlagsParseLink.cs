using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagValueParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParseLinks;

public class FlagsParseLink
{
    private readonly Dictionary<string, IFlagValueParseLink> _flags;

    private FlagsParseLink(Dictionary<string, IFlagValueParseLink> flags)
    {
        _flags = flags;
    }

    public static FlagsParseBuilder Builder => new();

    public ParseResult Apply(ConsoleParser.ArgumentsIterator iterator, ICommandBuilder builder)
    {
        ICommandBuilder thisBuilder = builder;
        while (iterator.Peek() && iterator.Current.StartsWith('-'))
        {
            if (_flags.ContainsKey(iterator.Current))
            {
                string currentFlagName = iterator.Current;
                iterator.MoveNext();
                ParseResult result = _flags[currentFlagName].Apply(iterator, thisBuilder);
                if (result is ParseResult.Failure)
                    return result;
                if (result is ParseResult.Success success)
                    thisBuilder = success.CommandBuilder;
            }
            else
            {
                return new ParseResult.Failure();
            }
        }

        return new ParseResult.Success(thisBuilder);
    }

    public class FlagsParseBuilder
    {
        private readonly Dictionary<string, IFlagValueParseLink> _flags = new();

        public FlagsParseBuilder AddFlagToParse(string flagName, IFlagValueParseLink flagValues)
        {
            _flags.TryAdd(flagName, flagValues);
            return this;
        }

        public FlagsParseLink Build()
        {
            return new FlagsParseLink(_flags);
        }
    }
}