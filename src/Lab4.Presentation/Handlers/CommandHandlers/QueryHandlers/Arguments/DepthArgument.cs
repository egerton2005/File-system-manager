using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class DepthArgument : SubCommandArgumentHandlerBase<TreeListCommandBuilder>
{
    public string Name => "-d";

    public override TreeListCommandBuilder Handle(IEnumerator<string> iterator, TreeListCommandBuilder builder)
    {
        var remainingArguments = new List<string>();
        do
        {
            if (iterator.Current != Name)
            {
                remainingArguments.Add(iterator.Current);
                continue;
            }

            if (!iterator.MoveNext())
                return Next is null ? builder : Next.Handle(remainingArguments.GetEnumerator(), builder);

            if (int.TryParse(iterator.Current, out int depth))
                return builder.WithDepth(depth);
        }
        while (iterator.MoveNext());

        return Next is null ? builder : Next.Handle(remainingArguments.GetEnumerator(), builder);
    }
}