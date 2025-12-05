namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class DisconnectCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new DisconnectCommandHandler();
    }
}