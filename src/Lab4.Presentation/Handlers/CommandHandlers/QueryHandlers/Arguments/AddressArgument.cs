using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class AddressArgument : SubCommandArgumentHandlerBase<ConnectCommandBuilder>
{
    public override ConnectCommandBuilder Handle(IEnumerator<string> iterator, ConnectCommandBuilder builder)
    {
        builder.WithDestinationPath(iterator.Current);

        if (iterator.MoveNext() && Next is not null)
        {
            return Next.Handle(iterator, builder);
        }

        return builder;
    }
}