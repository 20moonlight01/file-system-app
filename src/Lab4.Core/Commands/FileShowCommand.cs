using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Utilities.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileShowCommand : ICommand
{
    public static ICommandBuilder Builder => new FileShowCommandBuilder();

    public string Path { get; }

    public IOutputMode Mode { get; }

    private FileShowCommand(string path, IOutputMode mode)
    {
        Path = path;
        Mode = mode;
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

        FileSystemOperationResult result = manager.FileSystem.ShowFile(actualPath, Mode);
        if (result is FileSystemOperationResult.FileSystemError error)
            return new ExecutionResult.ExecutionError(error.Message);

        return new ExecutionResult.Success();
    }

    public class FileShowCommandBuilder : ICommandBuilder
    {
        public string? Path { get; private set; }

        public IOutputMode? Mode { get; private set; }

        public FileShowCommandBuilder WithPath(string path)
        {
            Path = path;
            return this;
        }

        public FileShowCommandBuilder WithMode(IOutputMode mode)
        {
            Mode = mode;
            return this;
        }

        public ICommand Build()
        {
            if (Path is null || Mode is null)
                throw new Exception();

            return new FileShowCommand(Path, Mode);
        }
    }
}