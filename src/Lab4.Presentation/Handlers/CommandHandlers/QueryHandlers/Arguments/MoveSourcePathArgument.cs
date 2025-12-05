using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class MoveSourcePathArgument : IPositionalArgument<FileMoveCommandBuilder>
{
    public FileMoveCommandBuilder Handle(IEnumerator<string> arguments, FileMoveCommandBuilder builder)
        => builder.WithSource(arguments.Current);
}