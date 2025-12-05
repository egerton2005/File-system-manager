namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class DefaultSystemFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new RootCommandHandler()
            .AddSubCommand(new ConnectCommandFactory().Create())
            .AddSubCommand(new DisconnectCommandFactory().Create())
            .AddSubCommand(new FileCommandFactory().Create())
            .AddSubCommand(new TreeCommandFactory().Create());
    }
}