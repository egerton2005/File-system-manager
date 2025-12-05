using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileDeleteCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new DeleteCommandHandler()
            .AddPositionalArgument(new DeletePathArgument());
    }
}