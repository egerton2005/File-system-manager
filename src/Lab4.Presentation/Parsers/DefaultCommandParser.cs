using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class DefaultCommandParser : ICommandParser
{
    private readonly INameCommand _commandHandler;

    public CommandParsingResult Parse(IEnumerable<string> arguments)
    {
        using IEnumerator<string> iterator = arguments.GetEnumerator();

        CommandParsingResult resultHandler = _commandHandler.Handle(iterator);
        return resultHandler;
    }

    public DefaultCommandParser(INameCommand commandHandler)
    {
        _commandHandler = commandHandler;
    }
}