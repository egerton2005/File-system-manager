using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileRenameCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new RenameCommandHandler()
            .AddPositionalArgument(new RenamePathArgument())
            .AddPositionalArgument(new RenameNameArgument());
    }
}