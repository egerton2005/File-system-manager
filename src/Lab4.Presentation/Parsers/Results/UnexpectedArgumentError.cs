namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

public class UnexpectedArgumentError : ICommandParsingError
{
    public string Message => "Unexpected argument error";
}