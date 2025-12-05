namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers.QueryHandlers.Factories;

public class FileCommandFactory : ICommandHandlerFactory
{
    public INameCommand Create()
        => new FileCommandHandler()
            .AddSubCommand(new FileShowCommandFactory().Create())
            .AddSubCommand(new FileMoveCommandFactory().Create())
            .AddSubCommand(new FileCopyCommandFactory().Create())
            .AddSubCommand(new FileDeleteCommandFactory().Create())
            .AddSubCommand(new FileRenameCommandFactory().Create());
}