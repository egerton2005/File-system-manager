using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class ConnectCommandHandler : CommandWithBuilderBase<ConnectCommandBuilder>
{
    public override string Name => "connect";
}