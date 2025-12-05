using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Arguments;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileCopyCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
    {
        return new CopyCommandHandler()
            .AddPositionalArgument(new CopySourcePathArgument())
            .AddPositionalArgument(new CopyDestinationPathArgument());
    }
}