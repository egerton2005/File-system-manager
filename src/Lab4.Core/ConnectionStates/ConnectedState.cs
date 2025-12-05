using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionStates;

public class ConnectedState : IConnectionState
{
    public ICommandResult TryConnect(FileSystemCore core, string path, IFileSystemMode? fsMode)
        => new FailureResult(new AlreadyConnectedError());

    public ICommandResult TryDisconnect(FileSystemCore core)
    {
        core.UpdateState(new DisconnectedState());
        return new SuccessVoidResult();
    }

    public ICommandResult TryFileMove(FileSystemCore core, string source, string destination)
    {
        PathUtilityResult s = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, source);
        PathUtilityResult d = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, destination);
        if (s is PathUtilityResult.Failure || d is PathUtilityResult.Failure)
            return new FailureResult(new IncorrectPathFileSystemError());

        return core.FileMove(AsSuccess(s), AsSuccess(d));
    }

    public ICommandResult TryFileDelete(FileSystemCore core, string path)
    {
        PathUtilityResult p = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, path);
        if (p is PathUtilityResult.Failure)
            return new FailureResult(new IncorrectPathFileSystemError());

        return core.FileDelete(AsSuccess(p));
    }

    public ICommandResult TryFileShow(FileSystemCore core, string path, IFileShowMode fsMode)
    {
        PathUtilityResult p = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, path);
        if (p is PathUtilityResult.Failure)
            return new FailureResult(new IncorrectPathFileSystemError());

        return core.FileShow(AsSuccess(p), fsMode);
    }

    public ICommandResult TryFileCopy(FileSystemCore core, string source, string destination)
    {
        PathUtilityResult s = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, source);
        PathUtilityResult d = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, destination);
        if (s is PathUtilityResult.Failure || d is PathUtilityResult.Failure)
            return new FailureResult(new IncorrectPathFileSystemError());

        return core.FileCopy(AsSuccess(s), AsSuccess(d));
    }

    public ICommandResult TryFileRename(FileSystemCore core, string path, string name)
    {
        PathUtilityResult p = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, path);
        if (p is PathUtilityResult.Failure)
            return new FailureResult(new IncorrectPathFileSystemError());

        return core.FileRename(AsSuccess(p), name);
    }

    public ICommandResult TryTreeList(FileSystemCore core, int depth)
    {
        if (depth < 0)
            return new FailureResult(new NotPositiveDepthError());
        return core.TreeList(depth);
    }

    public ICommandResult TryTreeGoTo(FileSystemCore core, string path)
    {
        PathUtilityResult p = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, path);
        if (p is PathUtilityResult.Failure)
            return new FailureResult(new IncorrectPathFileSystemError());

        return core.TreeGoTo(AsSuccess(p));
    }

    private static string AsSuccess(PathUtilityResult result)
    {
        return ((PathUtilityResult.Success)result).Value;
    }
}