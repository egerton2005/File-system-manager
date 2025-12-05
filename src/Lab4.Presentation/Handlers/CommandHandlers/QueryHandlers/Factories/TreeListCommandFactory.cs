using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class TreeListCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new ListCommandHandler()
            .AddFlagArgument(new DepthArgument());
    }
}