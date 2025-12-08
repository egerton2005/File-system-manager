namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    void FileMove(string source, string destination);

    void FileDelete(string path);

    void FileCopy(string source, string destination);

    Stream? GetFileStream(string path);

    string? Combine(string? rootPath, string? fromPath, string toPath);

    string? GetDirectoryName(string path);
}