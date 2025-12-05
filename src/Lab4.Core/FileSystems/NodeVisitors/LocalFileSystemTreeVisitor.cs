using Itmo.ObjectOrientedProgramming.Lab4.Core.Formatters;
using Itmo.ObjectOrientedProgramming.Lab4.Core.IOSystem.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.NodeVisitors;

public class LocalFileSystemTreeVisitor : IFileSystemTreeVisitor
{
    private const int DefaultMaxDepth = 1;
    private readonly FileFormatter _formatter;
    private readonly IOutput _output;
    private int _maxDepth;

    public LocalFileSystemTreeVisitor(FileFormatter formatter, IOutput output)
    {
        _formatter = formatter;
        _output = output;
        _maxDepth = DefaultMaxDepth;
    }

    public void Visit(LocalFileNode node, int depth)
    {
        WriteNode(_formatter.FormatFile(node.Name, depth));
    }

    public void Visit(LocalDirectoryNode node, int depth)
    {
        WriteNode(_formatter.FormatDirectory(node.Name, depth));

        if (depth >= _maxDepth) return;

        foreach (IFileSystemNode element in node.GetChildren())
        {
            element.Accept(this, depth + 1);
        }
    }

    public void WriteNode(string node)
    {
        _output.WriteLine(node);
    }

    public bool SetMaxDepth(int maxDepth)
    {
        if (maxDepth < 0) return false;

        _maxDepth = maxDepth;
        return true;
    }
}