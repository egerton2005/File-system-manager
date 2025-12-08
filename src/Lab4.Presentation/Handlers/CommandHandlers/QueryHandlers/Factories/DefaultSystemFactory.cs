namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class DefaultSystemFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
    {
        return new RootCommandHandler()
            .AddNext(new ConnectCommandFactory().Create())
            .AddNext(new DisconnectCommandFactory().Create())
            .AddNext(new FileCommandFactory().Create())
            .AddNext(new TreeCommandFactory().Create());
    }
}