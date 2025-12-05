using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;

public class FileSystemContext : IFileSystemContext
{
    private readonly FileSystemCore _core;

    public FileSystemContext(FileSystemCore core)
    {
        _core = core;
    }

    public ICommandResult FileShow(string path, IFileShowMode fsMode) => _core.State.TryFileShow(_core, path, fsMode);

    public ICommandResult FileMove(string source, string destination) =>
        _core.State.TryFileMove(_core, source, destination);

    public ICommandResult FileCopy(string source, string destination) =>
        _core.State.TryFileCopy(_core, source, destination);

    public ICommandResult FileDelete(string path) => _core.State.TryFileDelete(_core, path);

    public ICommandResult FileRename(string path, string name) => _core.State.TryFileRename(_core, path, name);

    public ICommandResult Connect(string destinationPath, IFileSystemMode fsMode) => _core.State.TryConnect(_core, destinationPath, fsMode);

    public ICommandResult Disconnect() => _core.State.TryDisconnect(_core);

    public ICommandResult TreeGoTo(string path) => _core.State.TryTreeGoTo(_core, path);

    public ICommandResult TreeList(int depth) => _core.State.TryTreeList(_core, depth);
}