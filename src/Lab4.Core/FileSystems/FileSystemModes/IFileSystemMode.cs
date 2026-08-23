using Itmo.ObjectOrientedProgramming.Lab4.Core.Utilities.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;

public interface IFileSystemMode
{
    bool FileExists(string path);

    bool DirectoryExists(string path);

    FileSystemOperationResult CopyFile(string sourcePath, string destinationPath);

    FileSystemOperationResult DeleteFile(string path);

    FileSystemOperationResult MoveFile(string sourcePath, string destinationPath);

    FileSystemOperationResult ShowFile(string path, IOutputMode mode);

    IEnumerable<string> GetDirectories(string path);

    IEnumerable<string> GetFiles(string path);
}