using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Utilities.OutputModes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParserFactories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    private readonly ConsoleParser _parser = ConsoleParser.Builder
        .WithCommandParser(new ConnectCommandParserFactory())
        .WithCommandParser(new DisconnectCommandParserFactory())
        .WithCommandParser(new FileCommandParserFactory())
        .WithCommandParser(new TreeCommandParserFactory())
        .Build();

    [Fact]
    public void ConnectCommandParseTest()
    {
        // Arrange
        string input = "connect C:/ -m local";

        // Act
        ParseResult result = _parser.Parse(input);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success success)
        {
            ICommandBuilder commandBuilder = success.CommandBuilder;
            Assert.IsType<ConnectCommand.ConnectCommandBuilder>(commandBuilder);
            if (commandBuilder is ConnectCommand.ConnectCommandBuilder connectCommandBuilder)
            {
                Assert.Equal("C:/", connectCommandBuilder.Address);
                Assert.IsType<LocalFileSystemMode>(connectCommandBuilder.Mode);
            }
        }
    }

    [Fact]
    public void DisconnectCommandParseTest()
    {
        // Arrange
        string input = "disconnect";

        // Act
        ParseResult result = _parser.Parse(input);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success success)
        {
            ICommandBuilder commandBuilder = success.CommandBuilder;
            Assert.IsType<DisconnectCommand.DisconnectCommandBuilder>(commandBuilder);
        }
    }

    [Fact]
    public void TreeGotoCommandParseTest()
    {
        // Arrange
        string input = "tree goto C:/";

        // Act
        ParseResult result = _parser.Parse(input);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success success)
        {
            ICommandBuilder commandBuilder = success.CommandBuilder;
            Assert.IsType<TreeGotoCommand.TreeGotoCommandBuilder>(commandBuilder);
            if (commandBuilder is TreeGotoCommand.TreeGotoCommandBuilder treeGotoCommandBuilder)
            {
                Assert.Equal("C:/", treeGotoCommandBuilder.Path);
            }
        }
    }

    [Fact]
    public void TreeListCommandParseTest()
    {
        // Arrange
        string input = "tree list -d 1";

        // Act
        ParseResult result = _parser.Parse(input);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success success)
        {
            ICommandBuilder commandBuilder = success.CommandBuilder;
            Assert.IsType<TreeListCommand.TreeListCommandBuilder>(commandBuilder);
            if (commandBuilder is TreeListCommand.TreeListCommandBuilder treeListCommandBuilder)
            {
                Assert.Equal(1, treeListCommandBuilder.Depth);
            }
        }
    }

    [Fact]
    public void FileShowCommandParseTest()
    {
        // Arrange
        string input = "file show C:/ -m console";

        // Act
        ParseResult result = _parser.Parse(input);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success success)
        {
            ICommandBuilder commandBuilder = success.CommandBuilder;
            Assert.IsType<FileShowCommand.FileShowCommandBuilder>(commandBuilder);
            if (commandBuilder is FileShowCommand.FileShowCommandBuilder fileShowCommandBuilder)
            {
                Assert.Equal("C:/", fileShowCommandBuilder.Path);
                Assert.IsType<ConsoleOutputMode>(fileShowCommandBuilder.Mode);
            }
        }
    }

    [Fact]
    public void FileMoveCommandParseTest()
    {
        // Arrange
        string input = "file move /dir1 /dir2";

        // Act
        ParseResult result = _parser.Parse(input);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success success)
        {
            ICommandBuilder commandBuilder = success.CommandBuilder;
            Assert.IsType<FileMoveCommand.FileMoveCommandBuilder>(commandBuilder);
            if (commandBuilder is FileMoveCommand.FileMoveCommandBuilder fileMoveCommandBuilder)
            {
                Assert.Equal("/dir1", fileMoveCommandBuilder.SourcePath);
                Assert.Equal("/dir2", fileMoveCommandBuilder.DestinationPath);
            }
        }
    }

    [Fact]
    public void FileCopyCommandParseTest()
    {
        // Arrange
        string input = "file copy /dir1 /dir2";

        // Act
        ParseResult result = _parser.Parse(input);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success success)
        {
            ICommandBuilder commandBuilder = success.CommandBuilder;
            Assert.IsType<FileCopyCommand.FileCopyCommandBuilder>(commandBuilder);
            if (commandBuilder is FileCopyCommand.FileCopyCommandBuilder fileCopyCommandBuilder)
            {
                Assert.Equal("/dir1", fileCopyCommandBuilder.SourcePath);
                Assert.Equal("/dir2", fileCopyCommandBuilder.DestinationPath);
            }
        }
    }

    [Fact]
    public void FileDeleteCommandParseTest()
    {
        // Arrange
        string input = "file delete /file";

        // Act
        ParseResult result = _parser.Parse(input);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success success)
        {
            ICommandBuilder commandBuilder = success.CommandBuilder;
            Assert.IsType<FileDeleteCommand.FileDeleteCommandBuilder>(commandBuilder);
            if (commandBuilder is FileDeleteCommand.FileDeleteCommandBuilder fileDeleteCommandBuilder)
            {
                Assert.Equal("/file", fileDeleteCommandBuilder.Path);
            }
        }
    }

    [Fact]
    public void FileRenameCommandParseTest()
    {
        // Arrange
        string input = "file rename /file filename";

        // Act
        ParseResult result = _parser.Parse(input);

        // Assert
        Assert.IsType<ParseResult.Success>(result);
        if (result is ParseResult.Success success)
        {
            ICommandBuilder commandBuilder = success.CommandBuilder;
            Assert.IsType<FileRenameCommand.FileRenameCommandBuilder>(commandBuilder);
            if (commandBuilder is FileRenameCommand.FileRenameCommandBuilder fileRenameCommandBuilder)
            {
                Assert.Equal("/file", fileRenameCommandBuilder.Path);
                Assert.Equal("filename", fileRenameCommandBuilder.FileName);
            }
        }
    }
}
