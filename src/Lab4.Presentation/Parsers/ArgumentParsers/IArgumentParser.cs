namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.ArgumentParsers;

public interface IArgumentParser
{
    IEnumerable<string> Parse(string input);
}