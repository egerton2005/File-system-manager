using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
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
    private readonly IPathUtility _pathUtility;

    private IFileSystem _fileSystem;

    private IFileSystemTreeVisitor _treeVisitor;

    private string _rootPath;

    private string _currentPath;

    public FileSystemContext(IPathUtility utility)
    {
        _pathUtility = utility;
        _treeVisitor = new LocalFileSystemTreeVisitor(new FileFormatter.Builder().Build(), new ConsoleOutput());
        _fileSystem = new NullFileSystem();
        _rootPath = string.Empty;
        _currentPath = string.Empty;
    }

    public void SetFileSystemTreeVisitor(IFileSystemTreeVisitor visitor)
    {
        _treeVisitor = visitor;
    }

    public CommandResult FileShow(string path, IFileShowMode fsMode)
    {
        PathUtilityResult p = _pathUtility.GoToPath(_rootPath, _currentPath, path);
        if (p is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        path = AsSuccess(p);

        try
        {
            using Stream stream = _fileSystem.GetFileStream(path);
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
        PathUtilityResult s = _pathUtility.GoToPath(_rootPath, _currentPath, source);
        PathUtilityResult d = _pathUtility.GoToPath(_rootPath, _currentPath, destination);
        if (s is PathUtilityResult.Failure || d is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        source = AsSuccess(s);
        destination = AsSuccess(d);

        string target = _pathUtility.CombinePaths(destination, Path.GetFileName(source));

        try
        {
            _fileSystem.FileMove(source, target);
            return new CommandResult.Success();
        }
        catch (Exception e)
        {
            return new CommandResult.Failure(new NotSupportedError(e.Message));
        }
    }

    public CommandResult FileCopy(string source, string destination)
    {
        PathUtilityResult s = _pathUtility.GoToPath(_rootPath, _currentPath, source);
        PathUtilityResult d = _pathUtility.GoToPath(_rootPath, _currentPath, destination);
        if (s is PathUtilityResult.Failure || d is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        source = AsSuccess(s);
        destination = AsSuccess(d);

        string target = _pathUtility.CombinePaths(destination, Path.GetFileName(source));

        try
        {
            _fileSystem.FileCopy(source, target);
            return new CommandResult.Success();
        }
        catch (Exception e)
        {
            return new CommandResult.Failure(new NotSupportedError(e.Message));
        }
    }

    public CommandResult FileDelete(string path)
    {
        PathUtilityResult p = _pathUtility.GoToPath(_rootPath, _currentPath, path);
        if (p is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        path = AsSuccess(p);

        try
        {
            _fileSystem.FileDelete(path);
            return new CommandResult.Success();
        }
        catch (Exception e)
        {
            return new CommandResult.Failure(new NotSupportedError(e.Message));
        }
    }

    public CommandResult FileRename(string path, string name)
    {
        PathUtilityResult p = _pathUtility.GoToPath(_rootPath, _currentPath, path);
        if (p is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        path = AsSuccess(p);

        string? directory = _pathUtility.GetDirectoryName(path);
        string target = _pathUtility.CombinePaths(directory, name);
        if (directory != _pathUtility.GetDirectoryName(target))
            return new CommandResult.Failure(new IncorrectPathFileSystemError());
        try
        {
            _fileSystem.FileMove(path, target);
            return new CommandResult.Success();
        }
        catch (Exception e)
        {
            return new CommandResult.Failure(new NotSupportedError(e.Message));
        }
    }

    public CommandResult Connect(string destinationPath, IFileSystemMode fsMode)
    {
        if (_fileSystem is not NullFileSystem)
            return new CommandResult.Failure(new AlreadyConnectedError());

        PathUtilityResult d = _pathUtility.GoToPath(_rootPath, _currentPath, destinationPath);
        if (d is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        destinationPath = AsSuccess(d);

        _fileSystem = fsMode.CreateFileSystem();
        if (!_fileSystem.DirectoryExists(destinationPath))
            return new CommandResult.Failure(new NameNotExistsError());
        _rootPath = destinationPath;
        _currentPath = destinationPath;

        return new CommandResult.Success();
    }

    public CommandResult Disconnect()
    {
        if (_fileSystem is NullFileSystem)
            return new CommandResult.Failure(new NotConnectedError());
        _fileSystem = new NullFileSystem();
        return new CommandResult.Success();
    }

    public CommandResult TreeGoTo(string path)
    {
        PathUtilityResult p = _pathUtility.GoToPath(_rootPath, _currentPath, path);
        if (p is PathUtilityResult.Failure)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        path = AsSuccess(p);

        if (!_fileSystem.DirectoryExists(path))
            return new CommandResult.Failure(new IncorrectPathFileSystemError());
        _currentPath = path;
        return new CommandResult.Success();
    }

    // connect C:\Users\Eger\Desktop
    public CommandResult TreeList(int depth)
    {
        if (depth < 0)
            return new CommandResult.Failure(new NotPositiveDepthError());

        string? directoryName = _pathUtility.GetDirectoryName(_currentPath);
        if (directoryName is null)
            return new CommandResult.Failure(new IncorrectPathFileSystemError());

        var root = new LocalDirectoryNode(
            directoryName,
            _currentPath);

        _treeVisitor.SetMaxDepth(depth);
        _treeVisitor.Visit(root, 0);
        return new CommandResult.Success();
    }

    private static string AsSuccess(PathUtilityResult result)
    {
        return ((PathUtilityResult.Success)result).Value;
    }
}