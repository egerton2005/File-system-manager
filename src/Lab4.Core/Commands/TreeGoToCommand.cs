using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeGoToCommand : ICommand
{
    public string Path { get; }

    public TreeGoToCommand(string path)
    {
        Path = path;
    }

    public CommandResult Execute(IFileSystemContext fs)
    {
        return fs.TreeGoTo(Path);
    }
}
