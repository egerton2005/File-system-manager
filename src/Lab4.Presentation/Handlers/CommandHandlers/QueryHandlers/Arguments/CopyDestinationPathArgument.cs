using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class CopyDestinationPathArgument : SubCommandArgumentHandlerBase<FileCopyCommandBuilder>
{
    public override FileCopyCommandBuilder Handle(IEnumerator<string> iterator, FileCopyCommandBuilder builder)
    {
        builder.WithDestination(iterator.Current);

        if (iterator.MoveNext() && Next is not null)
        {
            return Next.Handle(iterator, builder);
        }

        return builder;
    }
}