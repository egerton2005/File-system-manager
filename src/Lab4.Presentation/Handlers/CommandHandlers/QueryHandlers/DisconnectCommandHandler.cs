using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class DisconnectCommandHandler : CommandWithBuilderBase<DisconnectCommandBuilder>
{
    public override string Name => "disconnect";
}