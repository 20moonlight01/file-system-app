using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileRenameCommand : ICommand
{
    public static ICommandBuilder Builder => new FileRenameCommandBuilder();

    public string Path { get; }

    public string FileName { get; }

    private FileRenameCommand(string path, string fileName)
    {
        Path = path;
        FileName = fileName;
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

        string newPath = manager.PathResolver.ChangeFileName(actualPath, FileName);

        if (manager.FileSystem.FileExists(newPath))
            return new ExecutionResult.ExecutionError("Name collision");

        FileSystemOperationResult result = manager.FileSystem.MoveFile(actualPath, newPath);
        if (result is FileSystemOperationResult.FileSystemError error)
            return new ExecutionResult.ExecutionError(error.Message);

        return new ExecutionResult.Success();
    }

    public class FileRenameCommandBuilder : ICommandBuilder
    {
        public string? Path { get; private set; }

        public string? FileName { get; private set; }

        public FileRenameCommandBuilder WithPath(string path)
        {
            Path = path;
            return this;
        }

        public FileRenameCommandBuilder WithFileName(string fileName)
        {
            FileName = fileName;
            return this;
        }

        public ICommand Build()
        {
            if (Path is null || FileName is null)
                throw new Exception();

            return new FileRenameCommand(Path, FileName);
        }
    }
}