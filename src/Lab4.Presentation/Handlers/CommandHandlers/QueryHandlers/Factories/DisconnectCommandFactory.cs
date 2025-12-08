namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class DisconnectCommandFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
    {
        return new DisconnectCommandHandler();
    }
}