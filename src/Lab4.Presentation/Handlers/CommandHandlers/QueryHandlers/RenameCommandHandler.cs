using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class RenameCommandHandler : CommandWithBuilderBase<FileRenameCommandBuilder>
{
    public override string Name => "rename";
}