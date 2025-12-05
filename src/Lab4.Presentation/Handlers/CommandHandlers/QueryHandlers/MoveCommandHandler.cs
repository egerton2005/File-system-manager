using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class MoveCommandHandler : CommandWithBuilderBase<FileMoveCommandBuilder>
{
    public override string Name => "move";
}