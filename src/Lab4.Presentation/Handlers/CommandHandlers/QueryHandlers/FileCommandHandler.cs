using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class FileCommandHandler : SubCommandHandlerBase
{
    public override string Name => "file";

    private readonly ISubCommandHandler _subcommandHandler;

    public FileCommandHandler(ISubCommandHandler subcommandHandler)
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