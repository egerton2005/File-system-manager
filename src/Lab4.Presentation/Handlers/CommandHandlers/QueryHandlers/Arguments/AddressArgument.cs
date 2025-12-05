using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

public class AddressArgument : IPositionalArgument<ConnectCommandBuilder>
{
    public ConnectCommandBuilder Handle(IEnumerator<string> arguments, ConnectCommandBuilder builder)
        => builder.WithDestinationPath(arguments.Current);
}