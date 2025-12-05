using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class NullFileSystem : IFileSystem
{
    private readonly string _error = new NotConnectedError().Message;

    public bool FileExists(string path)
        => throw new InvalidOperationException(_error);

    public bool DirectoryExists(string path)
        => throw new InvalidOperationException(_error);

    public Stream GetFileStream(string path)
        => throw new InvalidOperationException(_error);

    public void FileMove(string source, string destination)
        => throw new InvalidOperationException(_error);

    public void FileDelete(string path)
        => throw new InvalidOperationException(_error);

    public string GetFileText(string path)
        => throw new InvalidOperationException(_error);

    public void FileCopy(string source, string destination)
        => throw new InvalidOperationException(_error);

    public void FileRename(string path, string name)
        => throw new InvalidOperationException(_error);
}