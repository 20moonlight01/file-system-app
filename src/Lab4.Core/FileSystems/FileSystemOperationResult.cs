namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public abstract record FileSystemOperationResult
{
    private FileSystemOperationResult() { }

    public sealed record Success : FileSystemOperationResult;

    public sealed record FileSystemError(string Message) : FileSystemOperationResult;
}