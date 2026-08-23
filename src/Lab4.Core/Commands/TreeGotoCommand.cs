using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeGotoCommand : ICommand
{
    public static ICommandBuilder Builder => new TreeGotoCommandBuilder();

    public string Path { get; }

    private TreeGotoCommand(string path)
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

        if (!manager.FileSystem.DirectoryExists(actualPath))
            return new ExecutionResult.ExecutionError("Directory or file not found");

        manager.PathResolver.SetCurrentPath(Path);

        return new ExecutionResult.Success();
    }

    public class TreeGotoCommandBuilder : ICommandBuilder
    {
        public string? Path { get; private set; }

        public TreeGotoCommandBuilder WithPath(string path)
        {
            Path = path;
            return this;
        }

        public ICommand Build()
        {
            if (Path is null)
                throw new Exception();

            return new TreeGotoCommand(Path);
        }
    }
}