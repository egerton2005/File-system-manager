using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class ShowPathArgument : IPositionalArgument<FileShowCommandBuilder>
{
    public FileShowCommandBuilder Handle(IEnumerator<string> arguments, FileShowCommandBuilder builder)
        => builder.WithPath(arguments.Current);
}