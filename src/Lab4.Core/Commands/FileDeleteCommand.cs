using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileDeleteCommand : ICommand
{
    public string Path { get; }

    public FileDeleteCommand(string path)
    {
        Path = path;
    }

    public CommandResult Execute(IFileSystemContext context)
    {
        if (context.IsDisconnect())
            return new CommandResult.Failure(new NotConnectedError());

        string? fullPath = context.FileSystem.Combine(context.RootPath, context.CurrentPath, Path);

        if (fullPath == null)
            return new CommandResult.Failure(new IncorrectedPathError());

        context.FileSystem.FileDelete(fullPath);
        return new CommandResult.Success();
    }
}