using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileDeleteCommand : ICommand
{
    public static ICommandBuilder Builder => new FileDeleteCommandBuilder();

    public string Path { get; }

    private FileDeleteCommand(string path)
    {
        Path = path;
    }

    public ExecutionResult Execute(FileSystemManager manager)
    {
        if (!manager.IsConnected || manager.PathResolver is null)
            return new ExecutionResult.ExecutionError("File system is not connected");

        string actualPath = manager.PathResolver.ResolvePath(Path);

        if (manager.PathResolver.PathOutOfSystem(Path))
            return new ExecutionResult.ExecutionError("Path out of bounds");

        if (!manager.FileSystem.FileExists(actualPath))
            return new ExecutionResult.ExecutionError("Directory or file not found");

        FileSystemOperationResult result = manager.FileSystem.DeleteFile(actualPath);
        if (result is FileSystemOperationResult.FileSystemError error)
            return new ExecutionResult.ExecutionError(error.Message);

        return new ExecutionResult.Success();
    }

    public class FileDeleteCommandBuilder : ICommandBuilder
    {
        public string? Path { get; private set; }

        public FileDeleteCommandBuilder WithPath(string path)
        {
            Path = path;
            return this;
        }

        public ICommand Build()
        {
            if (Path is null)
                throw new Exception();

            return new FileDeleteCommand(Path);
        }
    }
}