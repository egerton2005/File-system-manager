using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class MoveSourcePathArgument : SubCommandArgumentHandlerBase<FileMoveCommandBuilder>
{
    public override FileMoveCommandBuilder Handle(IEnumerator<string> iterator, FileMoveCommandBuilder builder)
    {
        builder.WithSource(iterator.Current);

        if (iterator.MoveNext() && Next is not null)
        {
            return Next.Handle(iterator, builder);
        }

        return builder;
    }
}