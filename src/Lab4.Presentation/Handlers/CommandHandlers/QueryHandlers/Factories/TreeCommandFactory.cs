namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class TreeCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new TreeCommandHandler()
            .AddSubCommand(new TreeGotoCommandFactory().Create())
            .AddSubCommand(new TreeListCommandFactory().Create());
    }
}