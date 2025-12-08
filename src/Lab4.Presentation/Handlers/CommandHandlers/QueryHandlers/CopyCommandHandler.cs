using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class CopyCommandHandler : SubCommandHandlerBase
{
    public override string Name => "copy";

    private readonly ISubCommandArgumentHandler<FileCopyCommandBuilder> _argumentHandler;

    public CopyCommandHandler(ISubCommandArgumentHandler<FileCopyCommandBuilder> copySubCommandBuilder)
    {
        _argumentHandler = copySubCommandBuilder;
    }

    public override CommandParsingResult Handle(IEnumerator<string> iterator)
    {
        CommandParsingResult error = new CommandParsingResult.Failure(new UnknownArgumentError());

        if (iterator.Current != Name)
        {
            return Next is null ? error : Next.Handle(iterator);
        }

        var commandBuilder = new FileCopyCommandBuilder();

        if (!iterator.MoveNext())
        {
            return new CommandParsingResult.Failure(new NotEnoughArgumentsError());
        }

        FileCopyCommandBuilder builder = _argumentHandler.Handle(iterator, commandBuilder);
        ICommand? command = builder.Build();

        if (command is null)
            return new CommandParsingResult.Failure(new NotEnoughArgumentsError());

        return new CommandParsingResult.Success(command);
    }
}
