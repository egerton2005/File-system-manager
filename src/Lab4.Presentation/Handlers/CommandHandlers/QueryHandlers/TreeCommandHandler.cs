using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class TreeCommandHandler : SubCommandHandlerBase
{
    public override string Name => "tree";

    private readonly ISubCommandHandler _subcommandHandler;

    public TreeCommandHandler(ISubCommandHandler subcommandHandler)
    {
        _subcommandHandler = subcommandHandler;
    }

    public override CommandParsingResult Handle(IEnumerator<string> iterator)
    {
        CommandParsingResult error = new CommandParsingResult.Failure(new UnknownArgumentError());

        if (iterator.Current != Name)
            return Next is null ? error : Next.Handle(iterator);

        if (!iterator.MoveNext())
        {
            return error;
        }

        return _subcommandHandler.Handle(iterator);
    }
}