using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DisconnectCommand : ICommand
{
    public static ICommandBuilder Builder => new DisconnectCommandBuilder();

    private DisconnectCommand() { }

    public ExecutionResult Execute(FileSystemManager manager)
    {
        if (!manager.IsConnected)
            return new ExecutionResult.ExecutionError("File system is not connected");

        manager.Disconnect();

        return new ExecutionResult.Success();
    }

    public class DisconnectCommandBuilder : ICommandBuilder
    {
        public ICommand Build()
        {
            return new DisconnectCommand();
        }
    }
}