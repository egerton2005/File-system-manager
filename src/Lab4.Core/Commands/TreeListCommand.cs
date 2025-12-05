using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeListCommand : ICommand
{
    public int Depth { get; }

    public TreeListCommand(int depth)
    {
        Depth = depth;
    }

    public ICommandResult Execute(IFileSystemContext fs)
    {
        return fs.TreeList(Depth);
    }
}
