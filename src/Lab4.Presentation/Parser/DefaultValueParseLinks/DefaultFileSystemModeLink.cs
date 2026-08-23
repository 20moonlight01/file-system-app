using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.DefaultValueParseLinks;

public class DefaultFileSystemModeLink : DefaultValueBaseLink
{
    public override ParseResult Apply(ICommandBuilder builder)
    {
        if (builder is ConnectCommand.ConnectCommandBuilder specificBuilder)
        {
            specificBuilder.WithMode(new LocalFileSystemMode());
            return CallNext(specificBuilder);
        }

        return new ParseResult.Failure();
    }
}