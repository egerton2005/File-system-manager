using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;

public interface INameCommand
{
    string Name { get; }

    CommandParsingResult Handle(IEnumerator<string> iterator);
}