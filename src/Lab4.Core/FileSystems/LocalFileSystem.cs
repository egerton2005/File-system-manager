using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultType;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public ICommandResult Connect(string destinationPath, IFileSystemMode? fsMode)
    {
        if (!Directory.Exists(destinationPath))
            return new FailureResult(new NameNotExistsError().Message);

        return new SuccessVoidResult();
    }

    public ICommandResult Disconnect()
    {
        return new SuccessVoidResult();
    }

    public ICommandResult FileMove(string source, string destination)
    {
        if (!File.Exists(source) || !Directory.Exists(destination))
            return new FailureResult(new NameNotExistsError().Message);

        string target = Path.Combine(destination, Path.GetFileName(source));

        if (File.Exists(target))
            return new FailureResult(new NameCollisionFileSystemError().Message);

        try
        {
            File.Move(source, target);
            return new SuccessVoidResult();
        }
        catch (Exception e)
        {
            return new FailureResult(e.Message);
        }
    }

    public ICommandResult FileDelete(string path)
    {
        if (!File.Exists(path))
            return new FailureResult(new NameNotExistsError().Message);

        try
        {
            File.Delete(path);
            return new SuccessVoidResult();
        }
        catch (Exception e)
        {
            return new FailureResult(e.Message);
        }
    }

    public ICommandResult FileShow(string path, IFileShowMode? fsMode)
    {
        if (!File.Exists(path))
            return new FailureResult(new IncorrectPathFileSystemError().Message);

        try
        {
            using FileStream stream = File.OpenRead(path);
            fsMode?.PrintFile(stream);
            return new SuccessVoidResult();
        }
        catch (Exception e)
        {
            return new FailureResult(e.Message);
        }
    }

    public ICommandResult FileCopy(string source, string destination)
    {
        if (!File.Exists(source) || !Directory.Exists(destination))
            return new FailureResult(new NameNotExistsError().Message);

        string target = Path.Combine(destination, Path.GetFileName(source));

        if (File.Exists(target))
            return new FailureResult(new NameCollisionFileSystemError().Message);

        try
        {
            File.Copy(source, target);
            return new SuccessVoidResult();
        }
        catch (Exception e)
        {
            return new FailureResult(e.Message);
        }
    }

    public ICommandResult FileRename(string path, string name)
    {
        if (!File.Exists(path))
            return new FailureResult(new NameNotExistsError().Message);

        string? directory = Path.GetDirectoryName(path);

        if (directory is null || !Directory.Exists(directory))
            return new FailureResult(new IncorrectPathFileSystemError().Message);

        string target = Path.Combine(directory, name);

        if (File.Exists(target))
            return new FailureResult(new NameCollisionFileSystemError().Message);

        try
        {
            File.Move(path, target);
            return new SuccessVoidResult();
        }
        catch (Exception e)
        {
            return new FailureResult(e.Message);
        }
    }

    public ICommandResult TreeList(int depth)
    {
        throw new NotImplementedException();
    }

    public ICommandResult TreeGoTo(string path)
    {
        if (!Directory.Exists(path))
            return new FailureResult(new NameNotExistsError().Message);
        return new SuccessVoidResult();
    }
}