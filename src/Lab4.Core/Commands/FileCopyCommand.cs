using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileCopyCommand : ICommand
{
    public string SourcePath { get; }

    public string DestinationPath { get; }

    public FileCopyCommand(string source, string destination)
    {
        SourcePath = source;
        DestinationPath = destination;
    }

    public CommandResult Execute(IFileSystemContext context)
    {
        if (context.IsDisconnect())
            return new CommandResult.Failure(new NotConnectedError());

        string? source = context.FileSystem.Combine(context.RootPath, context.CurrentPath, SourcePath);
        string? destination = context.FileSystem.Combine(context.RootPath, context.CurrentPath, DestinationPath);

        if (source == null || destination == null)
            return new CommandResult.Failure(new IncorrectedPathError());

        context.FileSystem.FileCopy(source, destination);
        return new CommandResult.Success();
    }
}
