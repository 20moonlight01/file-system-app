using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileMoveCommand : ICommand
{
    public static ICommandBuilder Builder => new FileMoveCommandBuilder();

    public string SourcePath { get; }

    public string DestinationPath { get; }

    private FileMoveCommand(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public ExecutionResult Execute(FileSystemManager manager)
    {
        if (!manager.IsConnected || manager.PathResolver is null)
            return new ExecutionResult.ExecutionError("File system is not connected");

        string actualSourcePath = manager.PathResolver.ResolvePath(SourcePath);
        string actualDestinationPath = manager.PathResolver.ResolvePath(DestinationPath);
        string fileNewPath = manager.PathResolver.ChangeFilePath(actualSourcePath, actualDestinationPath);

        if (manager.PathResolver.PathOutOfSystem(SourcePath) || manager.PathResolver.PathOutOfSystem(DestinationPath))
            return new ExecutionResult.ExecutionError("Path out of bounds");

        if (!manager.FileSystem.FileExists(actualSourcePath) || !manager.FileSystem.DirectoryExists(actualDestinationPath))
            return new ExecutionResult.ExecutionError("Directory or file not found");

        if (manager.FileSystem.FileExists(fileNewPath))
            return new ExecutionResult.ExecutionError("Name collision");

        FileSystemOperationResult result = manager.FileSystem.MoveFile(actualSourcePath, fileNewPath);
        if (result is FileSystemOperationResult.FileSystemError error)
            return new ExecutionResult.ExecutionError(error.Message);

        return new ExecutionResult.Success();
    }

    public class FileMoveCommandBuilder : ICommandBuilder
    {
        public string? SourcePath { get; private set; }

        public string? DestinationPath { get; private set; }

        public FileMoveCommandBuilder WithSourcePath(string sourcePath)
        {
            SourcePath = sourcePath;
            return this;
        }

        public FileMoveCommandBuilder WithDestinationPath(string destinationPath)
        {
            DestinationPath = destinationPath;
            return this;
        }

        public ICommand Build()
        {
            if (SourcePath is null || DestinationPath is null)
                throw new Exception();

            return new FileMoveCommand(SourcePath, DestinationPath);
        }
    }
}