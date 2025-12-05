using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class DepthArgument : IFlagArgument<TreeListCommandBuilder>
{
    public string Name => "-d";

    public TreeListCommandBuilder Handle(IEnumerator<string> arguments, TreeListCommandBuilder builder)
    {
        if (arguments.MoveNext() && int.TryParse(arguments.Current, out int depth))
            return builder.WithDepth(depth);

        return builder;
    }
}