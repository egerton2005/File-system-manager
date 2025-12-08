using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class CopySourcePathArgument : SubCommandArgumentHandlerBase<FileCopyCommandBuilder>
{
    public override FileCopyCommandBuilder Handle(IEnumerator<string> iterator, FileCopyCommandBuilder builder)
    {
        builder.WithSource(iterator.Current);

        if (iterator.MoveNext() && Next is not null)
        {
            return Next.Handle(iterator, builder);
        }

        return builder;
    }
}