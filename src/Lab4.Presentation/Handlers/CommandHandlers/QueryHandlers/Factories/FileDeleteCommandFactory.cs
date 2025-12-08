using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileDeleteCommandFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
    {
        return new DeleteCommandHandler(new DeletePathArgument());
    }
}