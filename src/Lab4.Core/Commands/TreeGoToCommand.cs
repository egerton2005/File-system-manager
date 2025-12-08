using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeGoToCommand : ICommand
{
    public string Path { get; }

    public TreeGoToCommand(string path)
    {
        Path = path;
    }

    public CommandResult Execute(IFileSystemContext context)
    {
        if (context.IsDisconnect())
            return new CommandResult.Failure(new NotConnectedError());

        string? path = context.FileSystem.Combine(context.RootPath, context.CurrentPath, Path);
        if (path == null || !context.SetCurrentPath(path))
            return new CommandResult.Failure(new IncorrectedPathError());
        return new CommandResult.Success();
    }
}
