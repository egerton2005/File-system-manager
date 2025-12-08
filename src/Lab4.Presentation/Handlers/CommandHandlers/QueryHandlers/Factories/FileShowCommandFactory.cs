using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments.ResponsibilityChainMods.ShowModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileShowCommandFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
    {
        return new ShowCommandHandler(
            new ShowPathArgument()
            .AddNext(new ShowModeArgument(new DefaultShowModeCheckerFactory().Create())));
    }
}