using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParserFactories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser;

public class ConsoleParser : IParser
{
    private readonly ICommandParseLink _commandParsers;

    public static ConsoleParserBuilder Builder => new ConsoleParserBuilder();

    private ConsoleParser(ICommandParseLink commandParsers)
    {
        _commandParsers = commandParsers;
    }

    public ParseResult Parse(string input)
    {
        var iterator = new ArgumentsIterator(input.Split(' '));

        ParseResult result = _commandParsers.Apply(iterator);
        if (result is ParseResult.Success && iterator.Peek())
            return new ParseResult.Failure();

        return result;
    }

    public class ConsoleParserBuilder
    {
        private ICommandParseLink? _commandParsers;

        public ConsoleParserBuilder WithCommandParser(ICommandParserFactory commandParserFactory)
        {
            if (_commandParsers is null)
            {
                _commandParsers = commandParserFactory.Create();
            }
            else
            {
                _commandParsers.AddNext(commandParserFactory.Create());
            }

            return this;
        }

        public ConsoleParser Build()
        {
            if (_commandParsers is null)
                return new ConsoleParser(new CommandTerminalLink());

            return new ConsoleParser(_commandParsers.AddNext(new CommandTerminalLink()));
        }
    }

    public class ArgumentsIterator
    {
        private readonly string[] _args;
        private int _position = 0;

        public string Current => _args[_position];

        public ArgumentsIterator(string[] args)
        {
            _args = args;
        }

        public bool MoveNext()
        {
            if (_position == _args.Length)
                return false;

            _position++;

            return true;
        }

        public bool Peek()
        {
            return _position < _args.Length;
        }
    }
}