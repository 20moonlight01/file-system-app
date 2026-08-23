using Itmo.ObjectOrientedProgramming.Lab4.Core.Utilities.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;

public class LocalFileSystemMode : IFileSystemMode
{
    public bool FileExists(string path) => File.Exists(path);

    public bool DirectoryExists(string path) => Directory.Exists(path);

    public FileSystemOperationResult CopyFile(string sourcePath, string destinationPath)
    {
        try
        {
            File.Copy(sourcePath, destinationPath);
        }
        catch
        {
            return new FileSystemOperationResult.FileSystemError("Unknown error while copying file");
        }

        return new FileSystemOperationResult.Success();
    }

    public FileSystemOperationResult DeleteFile(string path)
    {
        try
        {
            File.Delete(path);
        }
        catch
        {
            return new FileSystemOperationResult.FileSystemError("Unknown error while deleting file");
        }

        return new FileSystemOperationResult.Success();
    }

    public FileSystemOperationResult MoveFile(string sourcePath, string destinationPath)
    {
        try
        {
            File.Move(sourcePath, destinationPath);
        }
        catch
        {
            return new FileSystemOperationResult.FileSystemError("Unknown error while moving file");
        }

        return new FileSystemOperationResult.Success();
    }

    public FileSystemOperationResult ShowFile(string path, IOutputMode mode)
    {
        try
        {
            var reader = new StreamReader(path);
            mode.WriteText(reader.ReadToEnd());
        }
        catch
        {
            return new FileSystemOperationResult.FileSystemError("Unknown error while showing file");
        }

        return new FileSystemOperationResult.Success();
    }

    public IEnumerable<string> GetDirectories(string path) => Directory.GetDirectories(path);

    public IEnumerable<string> GetFiles(string path) => Directory.GetFiles(path);
}