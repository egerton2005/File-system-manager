using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;

public interface IFileSystemContext
{
    string? RootPath { get; }

    string? CurrentPath { get; }

    IFileSystem FileSystem { get; }

    bool IsDisconnect();

    bool SetCurrentPath(string path);

    bool Connect(string destinationPath, IFileSystemMode fsMode);

    bool Disconnect();
}