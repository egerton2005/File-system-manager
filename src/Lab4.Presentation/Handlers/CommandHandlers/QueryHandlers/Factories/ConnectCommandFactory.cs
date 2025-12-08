using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.FilleSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class ConnectCommandFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
    {
        return new ConnectCommandHandler(
            new AddressArgument()
            .AddNext(new ModeArgument(new DefaultFileSystemModeCheckerFactory().Create())));
    }
}