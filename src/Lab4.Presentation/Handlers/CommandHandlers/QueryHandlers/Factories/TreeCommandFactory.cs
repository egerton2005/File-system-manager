namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class TreeCommandFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
    {
        return new TreeCommandHandler(
            new TreeGotoCommandFactory().Create()
            .AddNext(new TreeListCommandFactory().Create()));
    }
}