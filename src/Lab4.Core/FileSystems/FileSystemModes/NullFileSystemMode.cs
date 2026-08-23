using Itmo.ObjectOrientedProgramming.Lab4.Core.Utilities.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;

public class NullFileSystemMode : IFileSystemMode
{
    public bool FileExists(string path) => false;

    public bool DirectoryExists(string path) => false;

    public FileSystemOperationResult CopyFile(string sourcePath, string destinationPath)
        => new FileSystemOperationResult.FileSystemError("File system not connected");

    public FileSystemOperationResult DeleteFile(string path)
        => new FileSystemOperationResult.FileSystemError("File system not connected");

    public FileSystemOperationResult MoveFile(string sourcePath, string destinationPath)
        => new FileSystemOperationResult.FileSystemError("File system not connected");

    public FileSystemOperationResult ShowFile(string path, IOutputMode mode)
        => new FileSystemOperationResult.FileSystemError("File system not connected");

    public IEnumerable<string> GetDirectories(string path) => [];

    public IEnumerable<string> GetFiles(string path) => [];
}