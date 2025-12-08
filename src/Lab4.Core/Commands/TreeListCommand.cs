using Itmo.ObjectOrientedProgramming.Lab4.Core.ConnectionContexts;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeListCommand : ICommand
{
    public int Depth { get; }

    public TreeListCommand(int depth)
    {
        Depth = depth;
    }

    public CommandResult Execute(IFileSystemContext context)
    {
        if (context.IsDisconnect() || context.CurrentPath is null)
            return new CommandResult.Failure(new NotConnectedError());
        if (Depth < 0)
            return new CommandResult.Failure(new NotPositiveDepthError());
        var visitor = new LocalFileSystemTreeVisitor(
            Depth,
            new FileFormatter.Builder().Build(),
            new ConsoleOutput());

        string? directoryName = context.FileSystem.GetDirectoryName(context.CurrentPath);
        if (directoryName is null)
            return new CommandResult.Failure(new IncorrectedPathError());
        visitor.Visit(new DirectoryNode(
            directoryName,
            context.CurrentPath));

        return new CommandResult.Success();
    }
}
