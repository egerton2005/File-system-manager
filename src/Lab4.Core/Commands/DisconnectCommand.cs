using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DisconnectCommand : ICommand
{
    public CommandResult Execute(IFileSystemContext context)
    {
        if (!context.Disconnect())
            return new CommandResult.Failure(new NotConnectedError());
        return new CommandResult.Success();
    }
}