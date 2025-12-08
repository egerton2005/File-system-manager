using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class RenameNameArgument : SubCommandArgumentHandlerBase<FileRenameCommandBuilder>
{
    public override FileRenameCommandBuilder Handle(IEnumerator<string> iterator, FileRenameCommandBuilder builder)
    {
        builder.WithName(iterator.Current);

        if (iterator.MoveNext() && Next is not null)
        {
            return Next.Handle(iterator, builder);
        }

        return builder;
    }
}