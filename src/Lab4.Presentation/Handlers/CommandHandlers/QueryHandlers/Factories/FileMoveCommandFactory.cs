using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileMoveCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new MoveCommandHandler()
            .AddPositionalArgument(new MoveSourcePathArgument())
            .AddPositionalArgument(new MoveDestinationPathArgument());
    }
}
