namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public abstract record ExecutionResult
{
    public sealed record Success : ExecutionResult;

    public sealed record ExecutionError(string Message) : ExecutionResult;
}