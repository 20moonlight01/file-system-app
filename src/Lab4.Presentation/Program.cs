using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParserFactories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main()
    {
        ConsoleParser parser = ConsoleParser.Builder
            .WithCommandParser(new ConnectCommandParserFactory())
            .WithCommandParser(new DisconnectCommandParserFactory())
            .WithCommandParser(new FileCommandParserFactory())
            .WithCommandParser(new TreeCommandParserFactory())
            .Build();

        var manager = new FileSystemManager();

        while (true)
        {
            string? input = Console.ReadLine();
            if (input is null)
                continue;

            ParseResult parseResult = parser.Parse(input);
            if (parseResult is ParseResult.Success success)
            {
                ICommandBuilder commandBuilder = success.CommandBuilder;
                try
                {
                    ICommand command = commandBuilder.Build();
                    ExecutionResult result = command.Execute(manager);
                    if (result is ExecutionResult.ExecutionError error)
                    {
                        Console.WriteLine(error.Message);
                    }
                    else
                    {
                        Console.WriteLine("Successfully executed");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Parsing failed");
                }
            }
            else
            {
                Console.WriteLine("Parsing failed");
            }
        }
    }
}