using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class TreeGotoCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new GoToCommandHandler()
            .AddPositionalArgument(new GoToPathArgument());
    }
}