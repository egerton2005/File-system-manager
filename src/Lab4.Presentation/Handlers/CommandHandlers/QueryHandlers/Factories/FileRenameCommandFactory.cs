using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileRenameCommandFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
    {
        return new RenameCommandHandler(
            new RenamePathArgument()
            .AddNext(new RenameNameArgument()));
    }
}