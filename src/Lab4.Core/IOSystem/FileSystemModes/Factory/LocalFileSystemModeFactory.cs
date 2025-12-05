namespace Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes.Factory;

public class LocalFileSystemModeFactory : IFileSystemModeFactory
{
    public string Name => "local";

    public IFileSystemMode Create()
        => new LocalFileSystemMode();
}