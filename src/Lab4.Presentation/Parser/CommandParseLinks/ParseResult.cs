using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

public abstract record ParseResult
{
    private ParseResult() { }

    public sealed record Success(ICommandBuilder CommandBuilder) : ParseResult;

    public sealed record Failure : ParseResult;
}