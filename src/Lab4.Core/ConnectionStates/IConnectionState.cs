using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionStates;

public interface IConnectionState
{
    ICommandResult TryConnect(FileSystemCore core, string path, IFileSystemMode? fsMode);

    ICommandResult TryDisconnect(FileSystemCore core);

    ICommandResult TryFileMove(FileSystemCore core, string source, string destination);

    ICommandResult TryFileDelete(FileSystemCore core, string path);

    ICommandResult TryFileShow(FileSystemCore core, string path, IFileShowMode? fsMode);

    ICommandResult TryFileCopy(FileSystemCore core, string source, string destination);

    ICommandResult TryFileRename(FileSystemCore core, string path, string name);

    ICommandResult TryTreeList(FileSystemCore core, int depth);

    ICommandResult TryTreeGoTo(FileSystemCore core, string path);
}