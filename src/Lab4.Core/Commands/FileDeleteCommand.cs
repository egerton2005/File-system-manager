using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileDeleteCommand : ICommand
{
    public string Path { get; }

    public FileDeleteCommand(string path)
    {
        Path = path;
    }

    public ICommandResult Execute(IFileSystemContext fs)
    {
        return fs.FileDelete(Path);
    }
}