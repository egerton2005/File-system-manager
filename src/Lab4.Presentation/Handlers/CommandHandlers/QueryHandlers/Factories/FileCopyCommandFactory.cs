using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileCopyCommandFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
    {
        return new CopyCommandHandler(
            new CopySourcePathArgument()
            .AddNext(new CopyDestinationPathArgument()));
    }
}