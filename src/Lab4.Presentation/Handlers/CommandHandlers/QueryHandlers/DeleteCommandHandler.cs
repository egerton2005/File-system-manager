using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class DeleteCommandHandler : SubCommandHandlerBase
{
    public override string Name => "delete";

    private readonly ISubCommandArgumentHandler<FileDeleteCommandBuilder> _argumentHandler;

    public DeleteCommandHandler(ISubCommandArgumentHandler<FileDeleteCommandBuilder> deleteSubCommandBuilder)
    {
        _argumentHandler = deleteSubCommandBuilder;
    }

    public override CommandParsingResult Handle(IEnumerator<string> iterator)
    {
        CommandParsingResult error = new CommandParsingResult.Failure(new UnknownArgumentError());

        if (iterator.Current != Name)
        {
            return Next is null ? error : Next.Handle(iterator);
        }

        var commandBuilder = new FileDeleteCommandBuilder();

        if (!iterator.MoveNext())
        {
            return new CommandParsingResult.Failure(new NotEnoughArgumentsError());
        }

        FileDeleteCommandBuilder builder = _argumentHandler.Handle(iterator, commandBuilder);
        ICommand? command = builder.Build();

        if (command is null)
            return new CommandParsingResult.Failure(new NotEnoughArgumentsError());

        return new CommandParsingResult.Success(command);
    }
}