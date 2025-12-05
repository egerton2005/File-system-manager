namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

public class NotEnoughArgumentsError : ICommandParsingError
{
    public string Message => "Not enough arguments required";
}