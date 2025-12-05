namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    bool FileExists(string path);

    bool DirectoryExists(string path);

    Stream GetFileStream(string path);

    void FileMove(string source, string destination);

    void FileDelete(string path);

    void FileCopy(string source, string destination);
}