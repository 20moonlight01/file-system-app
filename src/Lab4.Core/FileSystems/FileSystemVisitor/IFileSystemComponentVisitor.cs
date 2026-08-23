using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

public interface IFileSystemComponentVisitor
{
    void Visit(FileComponent component, int currentDepth, int maxDepth);

    void Visit(DirectoryComponent component, int currentDepth, int maxDepth);
}

public interface IFileSystemComponent
{
    IFileSystemMode FileSystemMode { get; }

    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor, int currentDepth, int maxDepth);
}