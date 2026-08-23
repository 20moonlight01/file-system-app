using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

public class DirectoryComponent : IFileSystemComponent
{
    private readonly string _path;

    private readonly PathResolver _pathResolver;

    public Queue<IFileSystemComponent> Components { get; } = new Queue<IFileSystemComponent>();

    public IFileSystemMode FileSystemMode { get; }

    public string Name => _pathResolver.GetFileName(_pathResolver.NormalizePath(_path));

    public DirectoryComponent(string path, IFileSystemMode fileSystemMode, PathResolver pathResolver)
    {
        _path = path;
        FileSystemMode = fileSystemMode;
        _pathResolver = pathResolver;
    }

    public void Accept(IFileSystemComponentVisitor visitor, int currentDepth, int maxDepth)
    {
        LoadComponents();
        visitor.Visit(this, currentDepth, maxDepth);
    }

    private void LoadComponents()
    {
        IEnumerable<string> files = FileSystemMode.GetFiles(_path);
        IEnumerable<string> directories = FileSystemMode.GetDirectories(_path);

        foreach (string file in files)
            Components.Enqueue(new FileComponent(file, FileSystemMode, _pathResolver));
        foreach (string directory in directories)
            Components.Enqueue(new DirectoryComponent(directory, FileSystemMode, _pathResolver));
    }
}