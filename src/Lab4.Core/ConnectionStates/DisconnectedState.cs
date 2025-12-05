using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionStates;

public class DisconnectedState : IConnectionState
{
    public ICommandResult TryConnect(FileSystemCore core, string path, IFileSystemMode fsMode)
    {
        PathUtilityResult rootRes = core.PathUtility.ResolveRootPath(path);
        if (rootRes is PathUtilityResult.Failure f)
            return new FailureResult(new IncorrectPathFileSystemError());

        string root = ((PathUtilityResult.Success)rootRes).Value;
        core.RootPath = root;
        core.CurrentPath = root;

        core.UpdateState(new ConnectedState());
        return core.Connect(root, fsMode);
    }

    public ICommandResult TryDisconnect(FileSystemCore core)
        => new FailureResult(new NotConnectedError());

    public ICommandResult TryFileMove(FileSystemCore core, string source, string destination)
        => new FailureResult(new NotConnectedError());

    public ICommandResult TryFileDelete(FileSystemCore core, string path)
        => new FailureResult(new NotConnectedError());

    public ICommandResult TryFileShow(FileSystemCore core, string path, IFileShowMode fsMode)
        => new FailureResult(new NotConnectedError());

    public ICommandResult TryFileCopy(FileSystemCore core, string source, string destination)
        => new FailureResult(new NotConnectedError());

    public ICommandResult TryFileRename(FileSystemCore core, string path, string name)
        => new FailureResult(new NotConnectedError());

    public ICommandResult TryTreeList(FileSystemCore core, int depth)
        => new FailureResult(new NotConnectedError());

    public ICommandResult TryTreeGoTo(FileSystemCore core, string path)
        => new FailureResult(new NotConnectedError());
}