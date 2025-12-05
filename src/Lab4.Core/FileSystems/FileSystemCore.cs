using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionStates;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class FileSystemCore
{
    public IConnectionState State { get; private set; }

    public IPathUtility PathUtility { get; }

    public IFileSystem FileSystem { get; private set; }

    public string RootPath { get; internal set; }

    public string CurrentPath { get; internal set; }

    public FileSystemCore(IPathUtility utility)
    {
        PathUtility = utility;
        State = new DisconnectedState();
        FileSystem = new NullFileSystem();
        RootPath = string.Empty;
        CurrentPath = string.Empty;
    }

    public ICommandResult Connect(string destinationPath, IFileSystemMode fsMode)
    {
        FileSystem = fsMode.CreateFileSystem();
        if (!FileSystem.DirectoryExists(destinationPath))
            return new FailureResult(new NameNotExistsError());

        return new SuccessVoidResult();
    }

    public ICommandResult Disconnect()
    {
        return new SuccessVoidResult();
    }

    public ICommandResult FileMove(string source, string destination)
    {
        if (!FileSystem.FileExists(source) || !FileSystem.DirectoryExists(destination))
            return new FailureResult(new NameNotExistsError());

        string target = PathUtility.CombinePaths(destination, Path.GetFileName(source));

        if (FileSystem.FileExists(target))
            return new FailureResult(new NameCollisionFileSystemError());

        try
        {
            FileSystem.FileMove(source, target);
            return new SuccessVoidResult();
        }
        catch (Exception e)
        {
            return new FailureResult(new NotSupportedError(e.Message));
        }
    }

    public ICommandResult FileDelete(string path)
    {
        if (!FileSystem.FileExists(path))
            return new FailureResult(new NameNotExistsError());

        try
        {
            FileSystem.FileDelete(path);
            return new SuccessVoidResult();
        }
        catch (Exception e)
        {
            return new FailureResult(new NotSupportedError(e.Message));
        }
    }

    public ICommandResult FileShow(string path, IFileShowMode fsMode)
    {
        if (!FileSystem.FileExists(path))
            return new FailureResult(new IncorrectPathFileSystemError());

        try
        {
            using Stream stream = FileSystem.GetFileStream(path);
            fsMode.PrintFile(stream);
            return new SuccessVoidResult();
        }
        catch (Exception e)
        {
            return new FailureResult(new NotSupportedError(e.Message));
        }
    }

    public ICommandResult FileCopy(string source, string destination)
    {
        if (!FileSystem.FileExists(source) || !FileSystem.DirectoryExists(destination))
            return new FailureResult(new NameNotExistsError());

        string target = PathUtility.CombinePaths(destination, Path.GetFileName(source));

        if (FileSystem.FileExists(target))
            return new FailureResult(new NameCollisionFileSystemError());

        try
        {
            FileSystem.FileCopy(source, target);
            return new SuccessVoidResult();
        }
        catch (Exception e)
        {
            return new FailureResult(new NotSupportedError(e.Message));
        }
    }

    public ICommandResult FileRename(string path, string name)
    {
        if (!FileSystem.FileExists(path))
            return new FailureResult(new NameNotExistsError());

        string? directory = PathUtility.GetDirectoryName(path);

        if (directory is null || !FileSystem.DirectoryExists(directory))
            return new FailureResult(new IncorrectPathFileSystemError());

        string target = PathUtility.CombinePaths(directory, name);

        if (FileSystem.FileExists(target))
            return new FailureResult(new NameCollisionFileSystemError());

        try
        {
            FileSystem.FileMove(path, target);
            return new SuccessVoidResult();
        }
        catch (Exception e)
        {
            return new FailureResult(new NotSupportedError(e.Message));
        }
    }

    public ICommandResult TreeList(int depth)
    {
        string? directoryName = PathUtility.GetDirectoryName(CurrentPath);
        if (directoryName is null)
            return new FailureResult(new IncorrectPathFileSystemError());

        IFileSystemNode root = new LocalDirectoryNode(
            directoryName,
            CurrentPath);

        return new SuccessTreeResult(root, depth);
    }

    public ICommandResult TreeGoTo(string path)
    {
        if (!FileSystem.DirectoryExists(path))
            return new FailureResult(new IncorrectPathFileSystemError());
        CurrentPath = path;
        return new SuccessVoidResult();
    }

    internal void UpdateState(IConnectionState newState)
        => State = newState;
}