using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileShowCommand : ICommand
{
    public string Path { get; }

    public IFileShowMode FileShowMode { get; }

    public FileShowCommand(string path, IFileShowMode fsMode)
    {
        Path = path;
        FileShowMode = fsMode;
    }

    public CommandResult Execute(IFileSystemContext context)
    {
        if (context.IsDisconnect())
            return new CommandResult.Failure(new NotConnectedError());

        string? path = context.FileSystem.Combine(context.RootPath, context.CurrentPath, Path);
        if (path == null)
            return new CommandResult.Failure(new IncorrectedPathError());
        using Stream? stream = context.FileSystem.GetFileStream(path);
        if (stream is null)
            return new CommandResult.Failure(new NotConnectedError());
        FileShowMode.PrintFile(stream);

        return new CommandResult.Success();
    }
}