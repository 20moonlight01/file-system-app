using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Utilities.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeListCommand : ICommand
{
    public static ICommandBuilder Builder => new TreeListCommandBuilder();

    public int Depth { get; }

    private TreeListCommand(int depth)
    {
        Depth = depth;
    }

    public ExecutionResult Execute(FileSystemManager manager)
    {
        if (!manager.IsConnected || manager.PathResolver is null)
            return new ExecutionResult.ExecutionError("File system is not connected");

        IFileSystemComponentVisitor visitor = new TreePrintingVisitor(
            new ConsoleOutputMode(),
            manager.VisitorSymbols);

        string startingPath = manager.PathResolver.NormalizePath(
            manager.PathResolver.ConnectionPath + manager.PathResolver.CurrentPath);

        var root = new DirectoryComponent(startingPath, manager.FileSystem, manager.PathResolver);
        root.Accept(visitor, 1, Depth);

        return new ExecutionResult.Success();
    }

    public class TreeListCommandBuilder : ICommandBuilder
    {
        public int? Depth { get; private set; }

        public TreeListCommandBuilder WithDepth(int depth)
        {
            Depth = depth;
            return this;
        }

        public ICommand Build()
        {
            if (Depth is null)
                throw new Exception();

            return new TreeListCommand(Depth.Value);
        }
    }
}