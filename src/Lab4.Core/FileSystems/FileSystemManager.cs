using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class FileSystemManager
{
    public IFileSystemMode FileSystem { get; private set; } = new NullFileSystemMode();

    public bool IsConnected { get; private set; }

    public PathResolver? PathResolver { get; private set; }

    public VisitorSymbols VisitorSymbols { get; } = new(FileSymbol: 'f', DirSymbol: 'd', IndentSymbol: '-');

    public void Connect(IFileSystemMode fileSystem, string address)
    {
        FileSystem = fileSystem;
        IsConnected = true;
        PathResolver = new PathResolver(address);
    }

    public void Disconnect()
    {
        FileSystem = new NullFileSystemMode();
        IsConnected = false;
        PathResolver = null;
    }
}