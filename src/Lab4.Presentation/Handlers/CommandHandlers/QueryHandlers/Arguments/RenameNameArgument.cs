using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class RenameNameArgument : IPositionalArgument<FileRenameCommandBuilder>
{
    public string Name => "rename";

    public FileRenameCommandBuilder Handle(IEnumerator<string> arguments, FileRenameCommandBuilder builder)
        => builder.WithName(arguments.Current);
}