using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;

public class FileSystemContext : IFileSystemContext
{
    public IPathUtility PathUtility { get; }

    public IFileSystem FileSystem { get; private set; }

    public IFileSystemTreeVisitor TreeVisitor { get; private set; }

    public string RootPath { get; internal set; }

    public string CurrentPath { get; internal set; }

    public FileSystemContext(IPathUtility utility)
    {
        PathUtility = utility;
        TreeVisitor = new LocalFileSystemTreeVisitor(new FileFormatter.Builder().Build(), new ConsoleOutput());
        FileSystem = new NullFileSystem();
        RootPath = string.Empty;
        CurrentPath = string.Empty;
    }

    public void SetFileSystemTreeVisitor(IFileSystemTreeVisitor visitor)
    {
        TreeVisitor = visitor;
    }

    public CommandResult FileShow(string path, IFileShowMode fsMode)
    {
        PathUtilityResult p = PathUtility.GoToPath(RootPath, CurrentPath, path);
        if (p is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        path = AsSuccess(p);

        try
        {
            using Stream stream = FileSystem.GetFileStream(path);
            fsMode.PrintFile(stream);
            return new CommandResult.Success();
        }
        catch (Exception e)
        {
            return new CommandResult.Failure(new NotSupportedError(e.Message));
        }
    }

    public CommandResult FileMove(string source, string destination)
    {
        PathUtilityResult s = PathUtility.GoToPath(RootPath, CurrentPath, source);
        PathUtilityResult d = PathUtility.GoToPath(RootPath, CurrentPath, destination);
        if (s is PathUtilityResult.Failure || d is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        source = AsSuccess(s);
        destination = AsSuccess(d);

        string target = PathUtility.CombinePaths(destination, Path.GetFileName(source));

        try
        {
            FileSystem.FileMove(source, target);
            return new CommandResult.Success();
        }
        catch (Exception e)
        {
            return new CommandResult.Failure(new NotSupportedError(e.Message));
        }
    }

    public CommandResult FileCopy(string source, string destination)
    {
        PathUtilityResult s = PathUtility.GoToPath(RootPath, CurrentPath, source);
        PathUtilityResult d = PathUtility.GoToPath(RootPath, CurrentPath, destination);
        if (s is PathUtilityResult.Failure || d is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        source = AsSuccess(s);
        destination = AsSuccess(d);

        string target = PathUtility.CombinePaths(destination, Path.GetFileName(source));

        try
        {
            FileSystem.FileCopy(source, target);
            return new CommandResult.Success();
        }
        catch (Exception e)
        {
            return new CommandResult.Failure(new NotSupportedError(e.Message));
        }
    }

    public CommandResult FileDelete(string path)
    {
        PathUtilityResult p = PathUtility.GoToPath(RootPath, CurrentPath, path);
        if (p is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        path = AsSuccess(p);

        try
        {
            FileSystem.FileDelete(path);
            return new CommandResult.Success();
        }
        catch (Exception e)
        {
            return new CommandResult.Failure(new NotSupportedError(e.Message));
        }
    }

    public CommandResult FileRename(string path, string name)
    {
        PathUtilityResult p = PathUtility.GoToPath(RootPath, CurrentPath, path);
        if (p is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        path = AsSuccess(p);

        string? directory = PathUtility.GetDirectoryName(path);
        string target = PathUtility.CombinePaths(directory, name);
        if (directory != PathUtility.GetDirectoryName(target))
            return new CommandResult.Failure(new IncorrectPathFileSystemError());
        try
        {
            FileSystem.FileMove(path, target);
            return new CommandResult.Success();
        }
        catch (Exception e)
        {
            return new CommandResult.Failure(new NotSupportedError(e.Message));
        }
    }

    public CommandResult Connect(string destinationPath, IFileSystemMode fsMode)
    {
        if (FileSystem is not NullFileSystem)
            return new CommandResult.Failure(new AlreadyConnectedError());

        PathUtilityResult d = PathUtility.GoToPath(RootPath, CurrentPath, destinationPath);
        if (d is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        destinationPath = AsSuccess(d);

        FileSystem = fsMode.CreateFileSystem();
        if (!FileSystem.DirectoryExists(destinationPath))
            return new CommandResult.Failure(new NameNotExistsError());
        RootPath = destinationPath;
        CurrentPath = destinationPath;

        return new CommandResult.Success();
    }

    public CommandResult Disconnect()
    {
        if (FileSystem is NullFileSystem)
            return new CommandResult.Failure(new NotConnectedError());
        FileSystem = new NullFileSystem();
        return new CommandResult.Success();
    }

    public CommandResult TreeGoTo(string path)
    {
        PathUtilityResult p = PathUtility.GoToPath(RootPath, CurrentPath, path);
        if (p is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        path = AsSuccess(p);

        if (!FileSystem.DirectoryExists(path))
            return new CommandResult.Failure(new IncorrectPathFileSystemError());
        CurrentPath = path;
        return new CommandResult.Success();
    }

    // connect C:\Users\Eger\Desktop
    public CommandResult TreeList(int depth)
    {
        if (depth < 0)
            return new CommandResult.Failure(new NotPositiveDepthError());

        string? directoryName = PathUtility.GetDirectoryName(CurrentPath);
        if (directoryName is null)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        var root = new LocalDirectoryNode(
            directoryName,
            CurrentPath);

        TreeVisitor.SetMaxDepth(depth);
        TreeVisitor.Visit(root, 0);
        return new CommandResult.Success();
    }

    private static string AsSuccess(PathUtilityResult result)
    {
        return ((PathUtilityResult.Success)result).Value;
    }
}