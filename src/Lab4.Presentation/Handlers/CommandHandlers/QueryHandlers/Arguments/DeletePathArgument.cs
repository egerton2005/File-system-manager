using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class DeletePathArgument : SubCommandArgumentHandlerBase<FileDeleteCommandBuilder>
{
    public override FileDeleteCommandBuilder Handle(IEnumerator<string> iterator, FileDeleteCommandBuilder builder)
    {
        builder.WithPath(iterator.Current);

        if (iterator.MoveNext() && Next is not null)
        {
            return Next.Handle(iterator, builder);
        }

        return builder;
    }
}