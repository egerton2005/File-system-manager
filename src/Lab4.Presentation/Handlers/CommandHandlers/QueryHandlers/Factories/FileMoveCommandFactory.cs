using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileMoveCommandFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
    {
        return new MoveCommandHandler(
            new MoveSourcePathArgument()
            .AddNext(new MoveDestinationPathArgument()));
    }
}
