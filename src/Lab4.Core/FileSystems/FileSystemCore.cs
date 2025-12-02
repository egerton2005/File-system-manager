using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionStates;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileSystemModes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemPathUtilities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class FileSystemCore
{
    public IConnectionState State { get; private set; }

    public IPathUtility PathUtility { get; }

    public IFileSystem FileSystem { get; private set; }

    public string RootPath { get; internal set; }

    public string CurrentPath { get; internal set; }

    public IFileSystemMode CurrentFileSystemMode { get; private set; }

    public IFileShowMode CurrentFileShowMode { get; private set; }

    public FileSystemCore(IPathUtility utility)
    {
        PathUtility = utility;
        State = new DisconnectedState();
        FileSystem = new NullFileSystem();
        RootPath = string.Empty;
        CurrentPath = string.Empty;
        CurrentFileSystemMode = new LocalFileSystemMode();
        CurrentFileShowMode = new ConsoleFileShowMode();
    }

    internal void UpdateState(IConnectionState newState)
        => State = newState;

    internal void UpdateFileSystemMode(IFileSystemMode newFileSystemMode)
    {
        CurrentFileSystemMode = newFileSystemMode;
        FileSystem = CurrentFileSystemMode.CreateFileSystem();
    }
}