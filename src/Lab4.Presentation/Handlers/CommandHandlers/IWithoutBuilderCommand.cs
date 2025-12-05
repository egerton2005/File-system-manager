namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;

public interface IWithoutBuilderCommand : INameCommand
{
    IWithoutBuilderCommand AddSubCommand(INameCommand link);
}