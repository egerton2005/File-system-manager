using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults.ResultVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;

public class SuccessTreeResult : ICommandResult
{
    public SuccessTreeResult(IFileSystemNode node, int depth)
    {
        Node = node;
        Depth = depth;
    }

    public IFileSystemNode Node { get; }

    public int Depth { get; }

    public void Accept(ICommandResultVisitor visitor)
        => visitor.Accept(this);
}