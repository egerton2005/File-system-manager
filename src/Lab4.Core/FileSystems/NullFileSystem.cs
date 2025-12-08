namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class NullFileSystem : IFileSystem
{
    public Stream? GetFileStream(string path) { return null; }

    public void FileMove(string source, string destination) { }

    public void FileDelete(string path) { }

    public void FileCopy(string source, string destination) { }

    public string? Combine(string? rootPath, string? fromPath, string toPath) { return null; }

    public string? GetDirectoryName(string path) { return null;  }
}