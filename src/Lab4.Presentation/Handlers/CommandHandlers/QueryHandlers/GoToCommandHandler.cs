using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class GoToCommandHandler : CommandWithBuilderBase<TreeGoToCommandBuilder>
{
    public override string Name => "goto";
}