using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DisconnectCommand : ICommand
{
    public CommandResult Execute(IFileSystemContext fs)
    {
        return fs.Disconnect();
    }
}