using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers;

public class CopyCommandHandler : CommandWithBuilderBase<FileCopyCommandBuilder>
{
    public override string Name => "copy";
}
