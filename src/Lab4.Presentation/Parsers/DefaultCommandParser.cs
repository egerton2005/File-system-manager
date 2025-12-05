using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class DefaultCommandParser : ICommandParser
{
    private readonly INameCommand _commandHandler;

    public CommandParsingResult Parse(IEnumerable<string> arguments)
    {
        using IEnumerator<string> iterator = arguments.GetEnumerator();
        var result = new CommandParsingResult.Failure(new NotEnoughArgumentsError());

        CommandParsingResult resultHandler = _commandHandler.Handle(iterator);
        if (resultHandler is CommandParsingResult.Success)
            return resultHandler;

        result = (CommandParsingResult.Failure)resultHandler;

        return result;
    }

    public DefaultCommandParser(INameCommand commandHandler)
    {
        _commandHandler = commandHandler;
    }
}