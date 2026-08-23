using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandParseLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.DefaultValueParseLinks;

public interface IDefaultValueParseLink
{
    ParseResult Apply(ICommandBuilder builder);

    IDefaultValueParseLink AddNext(IDefaultValueParseLink link);
}