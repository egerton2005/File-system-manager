using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class DisconnectCommandHandler : SubCommandHandlerBase
{
    public override string Name => "disconnect";

    public override CommandParsingResult Handle(IEnumerator<string> iterator)
    {
        CommandParsingResult error = new CommandParsingResult.Failure(new UnknownArgumentError());

        if (iterator.Current != Name)
        {
            return Next is null ? error : Next.Handle(iterator);
        }

        ICommand? command = new DisconnectCommandBuilder().Build();

        if (command is null)
            return new CommandParsingResult.Failure(new NotEnoughArgumentsError());

        return new CommandParsingResult.Success(command);
    }
}