namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

public class UnknownArgumentError : ICommandParsingError
{
    public string Message => "Unknown argument error";
}