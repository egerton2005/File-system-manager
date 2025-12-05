using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.FilleSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class ConnectCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new ConnectCommandHandler()
            .AddPositionalArgument(new AddressArgument())
            .AddFlagArgument(new ModeArgument(new DefaultFileSystemModeCheckerFactory().Create()));
    }
}