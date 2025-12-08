using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class RootCommandHandler : SubCommandHandlerBase
{
    public override string Name => string.Empty;

    public override CommandParsingResult Handle(IEnumerator<string> iterator)
    {
        CommandParsingResult error = new CommandParsingResult.Failure(new UnknownArgumentError());

        if (!iterator.MoveNext())
            return error;
        return Next is null ? error : Next.Handle(iterator);
    }
}