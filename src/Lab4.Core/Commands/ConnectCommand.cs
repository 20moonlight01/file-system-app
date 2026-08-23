using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    public static ICommandBuilder Builder => new ConnectCommandBuilder();

    public string Address { get; }

    public IFileSystemMode Mode { get; }

    private ConnectCommand(string address, IFileSystemMode mode)
    {
        Address = address;
        Mode = mode;
    }

    public ExecutionResult Execute(FileSystemManager manager)
    {
        if (manager.IsConnected)
            return new ExecutionResult.ExecutionError("File system is already connected");

        if (!Mode.DirectoryExists(Address))
            return new ExecutionResult.ExecutionError("Connection failed");

        manager.Connect(Mode, Address);

        return new ExecutionResult.Success();
    }

    public class ConnectCommandBuilder : ICommandBuilder
    {
        public string? Address { get; private set; }

        public IFileSystemMode? Mode { get; private set; }

        public ConnectCommandBuilder WithAddress(string address)
        {
            Address = address;
            return this;
        }

        public ConnectCommandBuilder WithMode(IFileSystemMode mode)
        {
            Mode = mode;
            return this;
        }

        public ICommand Build()
        {
            if (Address is null || Mode is null)
                throw new Exception();

            return new ConnectCommand(Address, Mode);
        }
    }
}