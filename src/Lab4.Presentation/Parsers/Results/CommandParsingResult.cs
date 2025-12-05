using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

public abstract record CommandParsingResult
{
    private CommandParsingResult() { }

    public sealed record Success(ICommand Command) : CommandParsingResult;

    public sealed record Failure(ICommandParsingError Error) : CommandParsingResult;
}