namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public bool FileExists(string path)
        => File.Exists(path);

    public bool DirectoryExists(string path)
        => Directory.Exists(path);

    public Stream GetFileStream(string path)
        => File.OpenRead(path);

    public void FileMove(string source, string destination)
        => File.Move(source, destination);

    public void FileDelete(string path)
        => File.Delete(path);

    public void FileCopy(string source, string destination)
        => File.Copy(source, destination);
}