using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

public class FileComponent : IFileSystemComponent
{
    private readonly string _path;

    public IFileSystemMode FileSystemMode { get; }

    private readonly PathResolver _pathResolver;

    public string Name => _pathResolver.GetFileName(_pathResolver.NormalizePath(_path));

    public FileComponent(string path, IFileSystemMode fileSystemMode, PathResolver pathResolver)
    {
        _path = path;
        FileSystemMode = fileSystemMode;
        _pathResolver = pathResolver;
    }

    public void Accept(IFileSystemComponentVisitor visitor, int currentDepth, int maxDepth)
    {
        visitor.Visit(this, currentDepth, maxDepth);
    }
}