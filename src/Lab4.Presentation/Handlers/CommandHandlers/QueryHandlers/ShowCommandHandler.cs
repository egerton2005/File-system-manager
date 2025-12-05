using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class ShowCommandHandler : CommandWithBuilderBase<FileShowCommandBuilder>
{
    public override string Name => "show";
}