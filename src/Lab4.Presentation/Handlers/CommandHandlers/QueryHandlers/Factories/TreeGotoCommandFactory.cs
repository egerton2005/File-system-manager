using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class TreeGotoCommandFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
    {
        return new GoToCommandHandler(new GoToPathArgument());
    }
}