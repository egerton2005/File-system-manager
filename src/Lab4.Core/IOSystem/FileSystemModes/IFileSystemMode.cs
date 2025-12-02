using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;

public interface IFileSystemMode
{
    string Name { get; }

    IFileSystem CreateFileSystem();
}