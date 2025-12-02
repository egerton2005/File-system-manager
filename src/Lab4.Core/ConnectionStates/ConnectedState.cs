using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultType;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionStates;

public class ConnectedState : IConnectionState
{
    public ICommandResult TryConnect(FileSystemCore core, string path, IFileSystemMode? fsMode)
        => new FailureResult(new AlreadyConnectedError().Message);

    public ICommandResult TryDisconnect(FileSystemCore core)
    {
        core.UpdateState(new DisconnectedState());
        return core.FileSystem.Disconnect();
    }

    public ICommandResult TryFileMove(FileSystemCore core, string source, string destination)
    {
        PathUtilityResult<string> s = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, source);
        if (s is PathUtilityResult<string>.Failure)
            return new FailureResult(new IncorrectPathFileSystemError().Message);

        PathUtilityResult<string> d = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, destination);
        if (d is PathUtilityResult<string>.Failure)
            return new FailureResult(new IncorrectPathFileSystemError().Message);

        return core.FileSystem.FileMove(AsSuccess(s), AsSuccess(d));
    }

    public ICommandResult TryFileDelete(FileSystemCore core, string path)
    {
        PathUtilityResult<string> p = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, path);
        if (p is PathUtilityResult<string>.Failure)
            return new FailureResult(new IncorrectPathFileSystemError().Message);

        return core.FileSystem.FileDelete(AsSuccess(p));
    }

    public ICommandResult TryFileShow(FileSystemCore core, string path, IFileShowMode? fsMode)
    {
        fsMode ??= core.CurrentFileShowMode;
        PathUtilityResult<string> p = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, path);
        if (p is PathUtilityResult<string>.Failure)
            return new FailureResult(new IncorrectPathFileSystemError().Message);

        return core.FileSystem.FileShow(AsSuccess(p), fsMode);
    }

    public ICommandResult TryFileCopy(FileSystemCore core, string source, string destination)
    {
        PathUtilityResult<string> s = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, source);
        if (s is PathUtilityResult<string>.Failure)
            return new FailureResult(new IncorrectPathFileSystemError().Message);

        PathUtilityResult<string> d = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, destination);
        if (d is PathUtilityResult<string>.Failure)
            return new FailureResult(new IncorrectPathFileSystemError().Message);

        return core.FileSystem.FileCopy(AsSuccess(s), AsSuccess(d));
    }

    public ICommandResult TryFileRename(FileSystemCore core, string path, string name)
    {
        PathUtilityResult<string> p = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, path);
        if (p is PathUtilityResult<string>.Failure)
            return new FailureResult(new IncorrectPathFileSystemError().Message);

        return core.FileSystem.FileRename(AsSuccess(p), name);
    }

    public ICommandResult TryTreeList(FileSystemCore core, int depth)
    {
        if (depth <= 0)
            return new FailureResult(new NotPositiveDepthError().Message);
        return core.FileSystem.TreeList(depth);
    }

    public ICommandResult TryTreeGoTo(FileSystemCore core, string path)
    {
        PathUtilityResult<string> p = core.PathUtility.GoToPath(core.RootPath, core.CurrentPath, path);
        if (p is PathUtilityResult<string>.Failure)
            return new FailureResult(new IncorrectPathFileSystemError().Message);

        ICommandResult commandResult = core.FileSystem.TreeGoTo(AsSuccess(p));
        if (commandResult is not FailureResult)
            core.CurrentPath = AsSuccess(p);
        return commandResult;
    }

    private static T AsSuccess<T>(PathUtilityResult<T> result)
    {
        return ((PathUtilityResult<T>.Success)result).Value;
    }
}