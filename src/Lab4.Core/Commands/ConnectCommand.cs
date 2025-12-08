using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    public string DestinationPath { get; }

    public IFileSystemMode FileSystemMode { get; }

    public ConnectCommand(string destinationPath, IFileSystemMode fsMode)
    {
        DestinationPath = destinationPath;
        FileSystemMode = fsMode;
    }

    public CommandResult Execute(IFileSystemContext context)
    {
        if (!context.Connect(DestinationPath, FileSystemMode))
            return new CommandResult.Failure(new AlreadyConnectedError());
        return new CommandResult.Success();
    }
}