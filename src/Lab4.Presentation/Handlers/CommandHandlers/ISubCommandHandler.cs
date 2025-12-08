namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Handlers.CommandHandlers;

public interface ISubCommandHandler : ISubCommand
{
    ISubCommandHandler AddNext(ISubCommandHandler link);
}