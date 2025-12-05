using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.ShowModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileShowCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new ShowCommandHandler()
            .AddPositionalArgument(new ShowPathArgument())
            .AddFlagArgument(new ShowModeArgument(new DefaultShowModeCheckerFactory().Create()));
    }
}