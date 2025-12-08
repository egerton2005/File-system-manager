using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileRenameCommand : ICommand
{
    public FileRenameCommand(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public string Path { get; }

    public string Name { get; }

    public CommandResult Execute(IFileSystemContext context)
    {
        if (context.IsDisconnect())
            return new CommandResult.Failure(new NotConnectedError());

        string? path = context.FileSystem.Combine(context.RootPath, context.CurrentPath, Path);
        if (path == null)
            return new CommandResult.Failure(new IncorrectedPathError());

        string? directory = context.FileSystem.GetDirectoryName(path);
        string? target = context.FileSystem.Combine(null, directory, Name);
        if (target is null || directory != context.FileSystem.GetDirectoryName(target))
            return new CommandResult.Failure(new IncorrectedPathError());

        context.FileSystem.FileMove(path, target);
        return new CommandResult.Success();
    }
}