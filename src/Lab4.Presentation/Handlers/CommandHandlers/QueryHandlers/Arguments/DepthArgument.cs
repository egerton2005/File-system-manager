using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class DepthArgument : SubCommandArgumentHandlerBase<TreeListCommandBuilder>
{
    public string Name => "-d";

    public override TreeListCommandBuilder Handle(IEnumerator<string> iterator, TreeListCommandBuilder builder)
    {
        if (iterator.Current != Name)
            return Next is null ? builder : Next.Handle(iterator, builder);

        if (!iterator.MoveNext())
            return builder;

        if (int.TryParse(iterator.Current, out int depth))
            return builder.WithDepth(depth);
        if (iterator.MoveNext() && Next is not null) return Next.Handle(iterator, builder);

        return builder;
    }
}