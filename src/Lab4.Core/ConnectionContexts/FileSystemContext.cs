using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;

public class FileSystemContext : IFileSystemContext
{
    public IFileSystem FileSystem { get; private set; }

    public string RootPath { get; private set; }

    public string CurrentPath { get; private set; }

    public FileSystemContext()
    {
        FileSystem = new NullFileSystem();
        RootPath = string.Empty;
        CurrentPath = string.Empty;
    }

    public bool SetCurrentPath(string path)
    {
        string? currentPath = FileSystem?.Combine(null, null, path);
        if (currentPath == null)
            return false;
        CurrentPath = currentPath;
        return true;
    }

    public bool IsDisconnect()
        => FileSystem is NullFileSystem;

    public bool Connect(string destinationPath, IFileSystemMode fsMode)
    {
        if (!IsDisconnect())
            return false;

        IFileSystem fileSystem = fsMode.CreateFileSystem();
        string? path = fileSystem.Combine(null, null, destinationPath);
        if (path is null)
            return false;
        FileSystem = fileSystem;
        RootPath = destinationPath;
        CurrentPath = destinationPath;
        return true;
    }

    public bool Disconnect()
    {
        if (IsDisconnect())
            return false;
        FileSystem = new NullFileSystem();
        return true;
    }
}