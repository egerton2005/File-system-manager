using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class DeleteCommandHandler : CommandWithBuilderBase<FileDeleteCommandBuilder>
{
    public override string Name => "delete";
}