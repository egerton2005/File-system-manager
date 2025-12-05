using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

public class LocalFileSystemMode : IFileSystemMode
{
    public IFileSystem CreateFileSystem()
    {
        return new LocalFileSystem();
    }
}