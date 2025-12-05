using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.FileShowModes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileShowCommand : ICommand
{
    public string Path { get; }

    public IFileShowMode FileShowMode { get; }

    public FileShowCommand(string path, IFileShowMode fsMode)
    {
        Path = path;
        FileShowMode = fsMode;
    }

    public ICommandResult Execute(IFileSystemContext fs)
    {
        return fs.FileShow(Path, FileShowMode);
    }
}