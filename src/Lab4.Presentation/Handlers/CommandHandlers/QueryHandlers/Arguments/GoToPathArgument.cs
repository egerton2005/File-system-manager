using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class GoToPathArgument : IPositionalArgument<TreeGoToCommandBuilder>
{
    public TreeGoToCommandBuilder Handle(IEnumerator<string> arguments, TreeGoToCommandBuilder builder)
        => builder.WithPath(arguments.Current);
}