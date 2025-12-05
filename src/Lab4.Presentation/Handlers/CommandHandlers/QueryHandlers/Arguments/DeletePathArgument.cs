using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class DeletePathArgument : IPositionalArgument<FileDeleteCommandBuilder>
{
    public FileDeleteCommandBuilder Handle(IEnumerator<string> arguments, FileDeleteCommandBuilder builder)
        => builder.WithPath(arguments.Current);
}