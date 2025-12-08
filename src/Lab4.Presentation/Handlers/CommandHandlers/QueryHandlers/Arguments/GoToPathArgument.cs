using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class GoToPathArgument : SubCommandArgumentHandlerBase<TreeGoToCommandBuilder>
{
    public override TreeGoToCommandBuilder Handle(IEnumerator<string> iterator, TreeGoToCommandBuilder builder)
    {
        builder.WithPath(iterator.Current);

        if (iterator.MoveNext() && Next is not null)
        {
            return Next.Handle(iterator, builder);
        }

        return builder;
    }
}