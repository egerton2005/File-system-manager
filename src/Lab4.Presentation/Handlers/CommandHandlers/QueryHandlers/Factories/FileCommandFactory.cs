namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileCommandFactory : ICommandHandlerFactory
{
    public ISubCommandHandler Create()
        => new FileCommandHandler(
            new FileShowCommandFactory().Create()
            .AddNext(new FileMoveCommandFactory().Create())
            .AddNext(new FileCopyCommandFactory().Create())
            .AddNext(new FileDeleteCommandFactory().Create())
            .AddNext(new FileRenameCommandFactory().Create()));
}