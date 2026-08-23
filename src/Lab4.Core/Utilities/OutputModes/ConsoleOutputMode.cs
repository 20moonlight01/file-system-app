namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Utilities.OutputModes;

public class ConsoleOutputMode : IOutputMode
{
    public void WriteText(string text) => Console.WriteLine(text);
}