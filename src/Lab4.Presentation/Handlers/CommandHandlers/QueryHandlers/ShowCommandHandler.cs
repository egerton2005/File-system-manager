using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class ShowCommandHandler : SubCommandHandlerBase
{
    public override string Name => "show";

    private readonly ISubCommandArgumentHandler<FileShowCommandBuilder> _argumentHandler;

    public ShowCommandHandler(ISubCommandArgumentHandler<FileShowCommandBuilder> deleteSubCommandBuilder)
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

        var commandBuilder = new FileShowCommandBuilder();

        if (!iterator.MoveNext())
        {
            return new CommandParsingResult.Failure(new NotEnoughArgumentsError());
        }

        FileShowCommandBuilder builder = _argumentHandler.Handle(iterator, commandBuilder);
        ICommand? command = builder.Build();

        if (command is null)
            return new CommandParsingResult.Failure(new NotEnoughArgumentsError());

        return new CommandParsingResult.Success(command);
    }
}