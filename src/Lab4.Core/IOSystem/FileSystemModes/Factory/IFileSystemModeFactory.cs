namespace Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes.Factory;

public interface IFileSystemModeFactory
{
    string Name { get; }

    IFileSystemMode Create();
}