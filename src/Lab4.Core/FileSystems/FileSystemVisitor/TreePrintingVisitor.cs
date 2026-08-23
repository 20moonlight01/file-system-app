using Itmo.ObjectOrientedProgramming.Lab4.Core.Utilities.OutputModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemVisitor;

public class TreePrintingVisitor : IFileSystemComponentVisitor
{
    private readonly IOutputMode _outputMode;
    private readonly VisitorSymbols _symbols;

    public TreePrintingVisitor(
        IOutputMode outputMode,
        VisitorSymbols symbols)
    {
        _outputMode = outputMode;
        _symbols = symbols;
    }

    public void Visit(FileComponent component, int currentDepth, int maxDepth)
    {
        string fileRecord = new(_symbols.IndentSymbol, currentDepth - 1);
        fileRecord += _symbols.FileSymbol;
        fileRecord += " " + component.Name;

        _outputMode.WriteText(fileRecord);
    }

    public void Visit(DirectoryComponent component, int currentDepth, int maxDepth)
    {
        string dirRecord = new(_symbols.IndentSymbol, currentDepth - 1);
        dirRecord += _symbols.DirSymbol;
        dirRecord += " " + component.Name;

        _outputMode.WriteText(dirRecord);

        if (currentDepth > maxDepth)
            return;

        while (component.Components.Count > 0)
        {
            IFileSystemComponent child = component.Components.Dequeue();
            child.Accept(this, currentDepth + 1, maxDepth);
        }
    }
}